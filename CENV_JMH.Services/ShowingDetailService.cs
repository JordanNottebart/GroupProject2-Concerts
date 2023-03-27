using CENV_JMH.DA;
using CENV_JMH.DO;

namespace CENV_JMH.Services
{
    public class ShowingDetailService
    {
        public List<ShowingInstance> GetShowingDetails()
        {
            using (var repo = new Repository())
            {
                return repo.Details.ToList();
            }
        }

        public ShowingInstance GetShowingDetailById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Details.FirstOrDefault(h => h.ShowingID == id) ?? new ShowingInstance();
            }
        }

        public void UpdateShowingDetail(ShowingInstance showingDetail)
        {
            using (var repo = new Repository())
            {
                repo.Details.Attach(showingDetail);

                var e = repo.ChangeTracker.Entries().FirstOrDefault(c => c.Entity ==  showingDetail);
                e.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                repo.SaveChanges();
            }
        }

        public void DeleteShowingDetail(int id)
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