using AgendaData;
using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaServices
{
    /// <summary>
    /// Questa classe rappresenta il punto di raccordo tra lo strato superiore e quelli inferiori
    /// per tutte le operazioni che riguardano i Contatti
    /// Questo livello serve anche per implementare una logica che non vada a intaccare il nostro dominio
    /// o le classi che si occupano di estrarre i dati
    /// </summary>
    public class ContattiService
    {
        /// <summary>
        /// Chiama il livello inferiore per richiedere un contatto specifico
        /// </summary>
        /// <param name="id">Id da passare al livello inferiore</param>
        public Contatto GetByID(int id)
        {
            DBContatto DBContatto = new DBContatto();
            return DBContatto.GetByID(id);
        }

        /// <summary>
        /// Metodo che mi ritorna la lista di contatti demandando la richiesta al livello inferiore
        /// </summary>
        public List<Contatto> GetAll()
        {
            DBContatto DBContatto = new DBContatto();
            return DBContatto.GetAll();
        }


        /// <summary>
        /// Metodo che demanda il salvataggio o l'aggiornamento ai piani inferiori dell'architettura
        /// Inoltre viene eseguita una prima validazione formale dell'input arrivato
        /// </summary>
        /// <param name="contatto">Contatto da inserire o aggiornare in base al numero del suo id</param>
        public void SaveOrUpdate(Contatto contatto)
        {
            //eseguo la validazione
            string error = contatto.Validate();
            if (string.IsNullOrEmpty(error))
            {
                ///nessun errore e procedo
                DBContatto DBContatto = new DBContatto();
                DBContatto.SaveOrUpdate(contatto);
                return;
            }

        }


        /// <summary>
        /// Metodo che demanda la cancellazione di un contatto ai piani inferiori dell'architettura
        /// </summary>
        /// <param name="id">Id del contatto da cancellare</param>
        public void Delete(int id)
        {
            DBContatto DBContatto = new DBContatto();
            DBContatto.Delete(id);
        }

    }
}
