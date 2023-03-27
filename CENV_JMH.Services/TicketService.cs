using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENV_JMH.Services
{
    public class TicketService
    {
        public List<Ticket> GetTickets() 
        {
            using (var repo = new Repository())
            {
                return repo.Tickets.ToList();
            }
        }

        public Ticket GetTicketById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Tickets.FirstOrDefault(c => c.ID == id) ?? new Ticket();
            }

        }

        public List<Ticket> GetTicketsByUser(int userId)
        {
            using (var repo = new Repository())
            {
                return repo.Tickets.Where(c => c.BuyerID == userId).ToList();
            }
        }

        public void AddTicket(Ticket ticket)
        {
            using (var repo = new Repository())
            {
                repo.Tickets.Add(ticket);
                repo.SaveChanges();
            }
        }

        public void UpdateTicket(Ticket ticket)
        {
            using (var repo = new Repository())
            {
                repo.Tickets.Attach(ticket);

                var e = repo.ChangeTracker.Entries().FirstOrDefault(c => c.Entity == ticket);
                e.State = EntityState.Modified;

                repo.SaveChanges();
            }
        }

        public void DeleteTicket(int id)
        {
            using (var repo = new Repository())
            {

                repo.Tickets.Remove(GetTicketById(id));
            }
        }
    }
}
