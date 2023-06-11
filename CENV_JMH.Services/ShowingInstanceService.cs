using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;

namespace CENV_JMH.Services
{
    #region ShowingInstance Services
    /// <summary>
    /// This class encapsulates the logic for CRUD (Create, Read, Update and Delete) operations on
    /// the "ShowingInstance" entity using a repository instance.
    /// </summary>
    #endregion

    public class ShowingInstanceService
    {
        public List<ShowingInstance> GetShowingInstance()
        {
            using (var repo = new Repository())
            {
                return repo.Details.Include(instance => instance.Hall).Include(instance => instance.Showing).ToList();
            }
        }

        public ShowingInstance GetShowingInstanceById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Details.Include(s => s.Hall).Include(instance => instance.Showing).FirstOrDefault(h => h.ID == id) ?? new ShowingInstance();
            }
        }

        public List<ShowingInstance> GetShowingInstancesByShowID(int showID)
        {
            using (var repo = new Repository())
            {
                return repo.Details.Include(c => c.Hall).Include(c => c.Showing).Where(d => d.ShowingID == showID).ToList() ?? new List<ShowingInstance>();
            }
        }

        public void UpdateShowingInstance(ShowingInstance showingDetail)
        {
            using (var repo = new Repository())
            {
                repo.Details.Attach(showingDetail);

                var e = repo.ChangeTracker.Entries().FirstOrDefault(c => c.Entity ==  showingDetail);
                e.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                repo.SaveChanges();
            }
        }

        public ShowingInstance? UpdateAndReturnShowingInstance(int id, ShowingInstance showingInstance)
        {
            using (var repo = new Repository())
            {
                var showingInstanceToUpdate = repo.Details.Where(instance => instance.ID == id).Include(instance => instance.Hall).Include(instance => instance.Showing).FirstOrDefault();

                if (showingInstanceToUpdate != null)
                {
                    showingInstanceToUpdate.ShowingID = showingInstance.ShowingID;
                    showingInstanceToUpdate.HallID = showingInstance.HallID;
                    showingInstanceToUpdate.Date = showingInstance.Date;

                    repo.Update(showingInstanceToUpdate);
                    repo.SaveChanges();

                    return showingInstanceToUpdate;
                }

                return null;
            }
        }

        public void DeleteShowingInstance(int id)
        {
            using (var repo = new Repository())
            {

                var todelete = repo.Details.FirstOrDefault(c => c.ID == id, null);
                if (todelete != null)
                {
                    repo.Details.Remove(todelete);
                    repo.SaveChanges();
                }
            }
        }

        public bool DeleteAndReturnBoolShowingInstance(int id)
        {
            using (var repo = new Repository())
            {
                var todelete = repo.Details.Include(instance => instance.Hall).Include(instance => instance.Showing).FirstOrDefault(instance => instance.ID == id);

                if (todelete != null)
                {
                    repo.Details.Remove(todelete);
                    repo.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public void CreateShowingInstance(ShowingInstance instance)
        {
            using (var repo = new Repository())
            {
                repo.Details.Add(instance);
                repo.SaveChanges();
            }
        }

        public ShowingInstance CreateAndReturnNewShowingInstance(ShowingInstance instance)
        {
            using (var repo = new Repository())
            {
                repo.Details.Add(instance);
                repo.SaveChanges();

                return instance;
            }
        }

        public ShowingInstance? UpdateStartTime(int id, DateTime startTime)
        {
            using (var repo = new Repository())
            {
                var showingInstanceToUpdate = repo.Details.Where(instance => instance.ID == id).Include(instance => instance.Hall).Include(instance => instance.Showing).FirstOrDefault();

                if (showingInstanceToUpdate != null)
                {
                    showingInstanceToUpdate.Date = startTime;

                    repo.Update(showingInstanceToUpdate);
                    repo.SaveChanges();

                    return showingInstanceToUpdate;
                }
                return null;
            }
        }
    }
}