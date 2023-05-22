using CENV_JMH.DA;
using CENV_JMH.DO;
using System;

namespace CENV_JMH.Services
{
    public class ShowingService
    {
        public Showing[] GetHomeShowings(int aantalShowings)
        {
            using (var repo = new Repository())
            {
                var returnarray = new Showing[aantalShowings];
                var x = repo.Showings.ToList();

                if (x.Count < aantalShowings)
                {
                    while (x.Count<aantalShowings)
                    {
                        x.Add(new Showing());
                    }
                }
                x.CopyTo(0, returnarray, 0, aantalShowings);
                return returnarray;
            }
        }
        public List<Showing> GetShowings()
        {
            using (var repo = new Repository())
            {
                return repo.Showings.ToList();
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
                    showToUpdate.Name = show.Name;
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