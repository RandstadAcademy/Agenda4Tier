using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MessageService.CompositeMessage
{
    class SmsService : IMessageService
    {
        public void Add(IMessageService messageService)
        {
            throw new NotImplementedException();
        }

        public void Send(MessagePayload messagePayload)
        {

            SendMessage(messagePayload);


        }

        public const string SMS_TYPE_CLASSIC = "send_sms_classic";

        static void SendMessage(MessagePayload messagePayload)
        {
            // Single dispatch
            String[] recipients = new String[] { "39" + messagePayload.Message.PhoneNumber };

            string sender="393334567456";


            Hashtable result = new Hashtable();
            Hashtable credit_result = new Hashtable();
            String line;

            // ------------ SMS Classic dispatch --------------

            // SMS CLASSIC dispatch with custom alphanumeric sender

            if (!String.IsNullOrEmpty(messagePayload.Message.Object))
            {
                sender = messagePayload.Message.Object;
            }


            result = skebbyGatewaySendSMS("randstadacademydotnet", "Casalino2016", recipients, messagePayload.Message.Body, SMS_TYPE_CLASSIC, sender, "", "", "");

            if ((string)result["status"] == "success")
            {
                Console.WriteLine("Message Sent!");
                Console.WriteLine("Remaining SMS: " + result["remaining_sms"]);

                if (result.ContainsKey("id"))
                {
                    Console.WriteLine("ID: " + result["id"]);
                }

            }


            if ((string)result["status"] == "failed")
            {
                Console.WriteLine("Sending failed");
                Console.WriteLine("Code: " + result["code"]);
                Console.WriteLine("Message: " + result["message"]);
            }
            line = Console.ReadLine();


        }

        private static Hashtable skebbyGatewaySendSMS(
            String username, String password,
            String[] recipients, String text,
            String sms_type, String sender_number,
            String sender_string,
            String user_reference,
            String charset)
        {
            String url = "http://gateway.skebby.it/api/send/smseasy/advanced/http.php";
            String result = "";
            String[] results, temp;
            String parameters = "";
            String method = SMS_TYPE_CLASSIC;
            int i = 0;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.ServicePoint.Expect100Continue = false;

            Hashtable r = new Hashtable();

            

            parameters = "method=" + HttpUtility.UrlEncode(method) + "&"
                         + "username=" + HttpUtility.UrlEncode(username) + "&password=" + HttpUtility.UrlEncode(password) + "&"
                         + "text=" + HttpUtility.UrlEncode(text) + "&"
                         + "recipients[]=" + string.Join("&recipients[]=", recipients);

            if (sender_number != "" && sender_string != "")
            {
                r.Add("status", "failed");
                r.Add("code", "0");
                r.Add("message", "You can specify only one type of sender, numeric or alphanumeric");
                return r;
            }

            parameters += sender_number != "" ? "&sender_number=" + HttpUtility.UrlEncode(sender_number) : "";
            parameters += sender_string != "" ? "&sender_string=" + HttpUtility.UrlEncode(sender_string) : "";

            parameters += user_reference != "" ? "&user_reference=" + HttpUtility.UrlEncode(user_reference) : "";

            switch (charset)
            {
                case "UTF-8":
                    parameters += "&charset=" + HttpUtility.UrlEncode("UTF-8");
                    break;
                default:
                    break;
            }

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(parameters);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse objResponse;
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            finally
            {
                myWriter.Close();
            }
            try
            {
                objResponse = (HttpWebResponse)objRequest.GetResponse();
            }
            catch (WebException e)
            {
                r.Add("status", "failed");
                r.Add("code", "0");
                r.Add("message", "Network error, unable to send the message");
                return r;
            }


            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }


            //se siamo arrivati qui è andato tutto bene
            results = result.Split('&');



            for (i = 0; i < results.Length; i++)
            {
                temp = results[i].Split('=');
                r.Add(temp[0], temp[1]);
            }
            return r;
        }





    }
}
