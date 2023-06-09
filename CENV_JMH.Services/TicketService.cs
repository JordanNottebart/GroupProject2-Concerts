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

        public List<Ticket> GetTicket(string User)
        {
            using (var repo = new Repository())
            {
                return repo.Tickets.Include(x => x.showingInstance).ThenInclude(instance => instance.Hall).Include(instance => instance.showingInstance.Showing).Where(t => t.userId == User).ToList();
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
