using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;

namespace CENV_JMH.Services
{
    public class TicketService
    {
        /// <summary>
        /// Retrieves a list of tickets for a specific user.
        /// </summary>
        /// <param name="user">The user identifier.</param>
        /// <returns>A list of tickets.</returns>
        public List<Ticket> GetTicket(string User)
        {
            using (var repo = new Repository())
            {
                return repo.Tickets
                    .Include(x => x.showingInstance)
                    .ThenInclude(instance => instance.Hall)
                    .Include(instance => instance.showingInstance.Showing)
                    .Where(t => t.userId == User)
                    .ToList();
            }
        }

        /// <summary>
        /// Creates a new ticket.
        /// </summary>
        /// <param name="ticket">The ticket to be created.</param>
        public void Create(Ticket ticket)
        {
            using (var repo = new Repository())
            {
                // Add the ticket to the repository and save changes
                repo.Tickets.Add(ticket);
                repo.SaveChanges();
            }
        }
    }
}
