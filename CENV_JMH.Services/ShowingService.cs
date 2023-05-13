using CENV_JMH.DA;
using CENV_JMH.DO;

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

        public void UpdateShowing(Showing showing)
        {
            using (var repo = new Repository())
            {
                repo.Showings.Attach(showing);

                var e = repo.ChangeTracker.Entries().FirstOrDefault(c => c.Entity ==  showing);
                e.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                repo.SaveChanges();
            }
        }

        public void DeleteShowing(int id)
        {
            using (var repo = new Repository())
            {

                var todelete = repo.Showings.ToList().FirstOrDefault(c => c.ShowingID == id, null);
                if (todelete != null)
                {

                    repo.Showings.Remove(todelete);
                    repo.SaveChanges();
                }
            }
        }

        public void CreateShowing(Showing showing)
        {
            using (var repo = new Repository())
            {
                repo.Showings.Add(showing);
                repo.SaveChanges();
            }
        }
    }
}