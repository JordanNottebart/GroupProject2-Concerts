using CENV_JMH.DA;
using CENV_JMH.DO;

namespace CENV_JMH.Services
{
    public class ShowingInstanceService
    {
        public List<ShowingInstance> GetShowingInstance()
        {
            using (var repo = new Repository())
            {
                return repo.Details.ToList();
            }
        }

        public ShowingInstance GetShowingInstanceById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Details.FirstOrDefault(h => h.ID == id) ?? new ShowingInstance();
            }
        }

        public List<ShowingInstance> GetShowingInstancesByShowID(int showID)
        {
            using (var repo = new Repository())
            {
                return repo.Details.Where(d => d.ShowingID == showID).ToList() ?? new List<ShowingInstance>();
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
    }
}