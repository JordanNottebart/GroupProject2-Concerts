using CENV_JMH.DA;
using CENV_JMH.DO;
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


        public List<Ticket> GetTicket(string User)
        {
            using (var repo = new Repository())
            {
                return repo.Tickets.Where(t => t.userId == User).ToList();
            }
        }

        public void Create(Ticket ticket)
        {
            using (var repo = new Repository())
            {
                repo.Tickets.Add(ticket);
                repo.SaveChanges();
            }
        }
    }
}
