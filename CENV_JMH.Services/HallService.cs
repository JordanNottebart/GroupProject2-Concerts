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

        public Hall UpdateAndCreateHall(Hall hall)
        {
            using (var repo = new Repository())
            {
                if (hall.HallID == 0)
                {
                    repo.Halls.Add(hall);
                }
                else
                {
                    repo.Halls.Attach(hall);

                    var e = repo.ChangeTracker
                        .Entries()
                        .FirstOrDefault(c => c.Entity == hall);
                    e.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                repo.SaveChanges();
                return hall;
            }
        }
        public void DeleteHall(int id)
        {
            using (var repo = new Repository())
            {

                var toDelete = repo.Halls.ToList().FirstOrDefault(c => c.HallID == id, null);
                if (toDelete != null)
                {
                    repo.Halls.Remove(toDelete);
                    repo.SaveChanges();
                }
            }
        }
    }
}

