using AgendaData;
using AgendaData.mermec;
using AgendaDomain;
using PersistenceSystem;
using PersistenceSystem.abstractions;
using PersistenceSystem.querying;
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
    public class ContattiService : IContattiService
    {
        /// <summary>
        /// Chiama il livello inferiore per richiedere un contatto specifico
        /// </summary>
        /// <param name="id">Id da passare al livello inferiore</param>
        public Contatto GetByID(int id)
        {
            return (Contatto)DBFacade.Instance().GetById("Contatto" ,id) ;
        }

        /// <summary>
        /// Metodo che mi ritorna la lista di contatti demandando la richiesta al livello inferiore
        /// </summary>
        public List<Contatto> GetAll()
        {
            List<Contatto> c = new List<Contatto>();

            List<AbstractDomainObject> l = DBFacade.Instance().GetAll("Contatto");

            //TomD88: questa fix serve giusto a far partire il progetto.Questo controllo non dovrebbe
            //        andare qui.Ricordatevi di controllarvi le connectionString e scegliere eventualmente dove
            //        aggiungere questo controllo
            if (l != null) l.ForEach(d => c.Add((Contatto)d));

            return c;
        }


        /// <summary>
        /// Metodo che demanda il salvataggio o l'aggiornamento ai piani inferiori dell'architettura
        /// Inoltre viene eseguita una prima validazione formale dell'input arrivato
        /// </summary>
        /// <param name="contatto">Contatto da inserire o aggiornare in base al numero del suo id</param>
        public void SaveOrUpdate(Contatto contatto)
        {
            //eseguo la validazione
            //contatto.ValidateMethod();
            DBFacade.Instance().SaveOrUpdate(contatto);           
        }


        /// <summary>
        /// Metodo che demanda la cancellazione di un contatto ai piani inferiori dell'architettura
        /// </summary>
        /// <param name="id">Id del contatto da cancellare</param>
        public void Delete(int id)
        {
            Contatto ng = new Contatto();
            ng.Id = id;
            DBFacade.Instance().Delete(ng);
        }

        public List<Contatto> Find(string text)
        {
            Query q = DBFacade.Instance().CreateQuery();

            //q.AddCriteria(_CRITERIA.MAtchCriteria())

            //AbstractCriteria c = new CompositeCriteria(BooleaOperator.Or);

            //AbstractCriteria name = new MatchCriteria("Name1", text);
            //AbstractCriteria tel = new MatchCriteria("Tel", text);
            //AbstractCriteria mail = new MatchCriteria("Mail", text);
            //AbstractCriteria type = new MatchCriteria("MessageType", text);

            //c.Add(name);
            //c.Add(tel);
            //c.Add(mail);
            //c.Add(type);
            //q.AddWhereclause(c);
            #region a
            //second attempt!
            //AbstractCriteria c = new CompositeCriteria(BooleaOperator.Or);

            //AbstractCriteria cSx = new CompositeCriteria(BooleaOperator.And);
            //AbstractCriteria cDx = new CompositeCriteria(BooleaOperator.And);

            //c.Add(cSx);
            //c.Add(cDx);

            //cSx.Add(new MatchCriteria("Campo1", text));
            //cSx.Add(new MatchCriteria("Campo2", text));

            //cDx.Add(new MatchCriteria("Campo3", text));
            //cDx.Add(new MatchCriteria("Campo4", text));
            #endregion a

            //q.AddCompositeCriteria(BooleaOperator.Or)
            //.AddCriteria(CriteriaFactory.MatchCriteria("Name1", text))
            //.AddCriteria(CriteriaFactory.MatchCriteria("Tel", text))
            //.AddCriteria(CriteriaFactory.MatchCriteria("Mail", text))
            //.AddCriteria(CriteriaFactory.MatchCriteria("MessageType", text))
            //.EndComposite();

            //q.AddCriteria(CriteriaFactory.MatchCriteria("Name1", text)).AddCriteria(CriteriaFactory.MatchCriteria("Name1", text));

            q.AddCriteria(CriteriaFactory.MatchCriteria("Name1", text));

            

            List<AbstractDomainObject> l = DBFacade.Instance().Find("Contatto", q);

            List<Contatto> c1 = new List<Contatto>();
            if (l != null) l.ForEach(d => c1.Add((Contatto)d));

            return c1;

        }

       
    }
}
