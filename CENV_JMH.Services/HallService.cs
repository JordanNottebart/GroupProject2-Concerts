using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;

namespace CENV_JMH.Services
{
    #region Hall Services
    /// <summary>
    /// This class encapsulates the logic for CRUD (Create, Read, Update and Delete) operations on
    /// the "Hall" entity using a repository instance.
    /// </summary>
    #endregion

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

        public Hall? UpdateHall(int id, Hall hall)
        {
            using (var repo = new Repository())
            {
                var hallToUpdate = repo.Halls.Where(h=>h.HallID == id).FirstOrDefault();

                if (hallToUpdate != null)
                {
                    hallToUpdate.Name = hall.Name;
                    hallToUpdate.MaxNumberOfPlaces = hall.MaxNumberOfPlaces;
                    repo.Update(hallToUpdate);
                    repo.SaveChanges();
                    return hallToUpdate;
                }
                return null;
            }
        }

        public Hall CreateHall(Hall hall)
        {
            using (var repo = new Repository())
            {
                repo.Halls.Add(hall);
                repo.SaveChanges();
                return hall;
            }
        }
 
        public bool DeleteHall(int id)
        {
            using (var repo = new Repository())
            {

                var toDelete = repo.Halls.ToList().FirstOrDefault(c => c.HallID == id, null);
                if (toDelete != null)
                {
                    repo.Halls.Remove(toDelete);
                    repo.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Hall? UpdateMaxNumberOfPlaces(int id, int maxNumberOfPlaces)
        {
            using (var repo = new Repository())
            {
                var hallToUpdate = repo.Halls.Where(h => h.HallID == id).FirstOrDefault();

                if (hallToUpdate != null)
                {
                    hallToUpdate.MaxNumberOfPlaces = maxNumberOfPlaces;

                    repo.Update(hallToUpdate);
                    repo.SaveChanges();

                    return hallToUpdate;
                }
                return null;
            }
        }
    }
}