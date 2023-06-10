using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;
using System;

namespace CENV_JMH.Services
{
    public class ShowingService
    {
        public Showing[] GetHomeShowings(int amountOfShowings)
        {
            using (var repo = new Repository())
            {
                var returnArray = new Showing[amountOfShowings];
                var showings = repo.Showings.ToList();

                if (showings.Count < amountOfShowings)
                {
                    while (showings.Count<amountOfShowings)
                    {
                        showings.Add(new Showing());
                    }
                }
                showings.CopyTo(0, returnArray, 0, amountOfShowings);
                return returnArray;
            }
        }
        public List<Showing> GetShowings()
        {
            using (var repo = new Repository())
            {
                return repo.Showings.Include(u => u.Hall).ToList();
            }
        }

        public Showing GetShowingById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Showings.FirstOrDefault(h => h.ShowingID == id) ?? new Showing();
            }
        }

        public Showing? UpdateShowing(int id, Showing show)
        {
            using (var repo = new Repository())
            {
                var showToUpdate = repo.Showings.Where(h => h.ShowingID == id).FirstOrDefault();

                if (showToUpdate != null)
                {
                    showToUpdate.ShowingName = show.ShowingName;
                    showToUpdate.TicketPrice = show.TicketPrice;
                    showToUpdate.Picture_URL = show.Picture_URL;
                    repo.Update(showToUpdate);
                    repo.SaveChanges();
                    return showToUpdate;
                }
                return null;
            }
        }

        public bool DeleteShowing(int id)
        {
            using (var repo = new Repository())
            {

                var todelete = repo.Showings.ToList().FirstOrDefault(c => c.ShowingID == id, null);
                if (todelete != null)
                {

                    repo.Showings.Remove(todelete);
                    repo.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Showing CreateShowing(Showing showing)
        {
            using (var repo = new Repository())
            {
                repo.Showings.Add(showing);
                repo.SaveChanges();
                return showing;
            }
        }
    }
}