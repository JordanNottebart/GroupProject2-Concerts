using CENV_JMH.DA;
using CENV_JMH.DO;

namespace CENV_JMH.Services
{
    public class HallService
    {
        public List<Hall> GetHalls()
        {
            using (var repo = new Repository())
            {
                return repo.Halls.ToList();
            }
        }

        public Hall GetHallById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Halls.FirstOrDefault(h => h.HallID == id) ?? new Hall();
            }
        }

        public void UpdateHall(Hall hall)
        {
            using (var repo = new Repository())
            {
                repo.Halls.Attach(hall);

                var e = repo.ChangeTracker.Entries().FirstOrDefault(c => c.Entity ==  hall);
                e.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                repo.SaveChanges();
            }
        }

        public void DeleteHall(int id)
        {
            using (var repo = new Repository())
            {

                var todelte = repo.Halls.FirstOrDefault(c => c.HallID == id, null);
                if (todelte != null)
                {

                    repo.Halls.Remove(todelte);
                    repo.SaveChanges();
                }
            }
        }
    }
}