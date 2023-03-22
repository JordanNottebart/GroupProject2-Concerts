using CENV_JMH.DA;
using CENV_JMH.DO;

namespace CENV_JMH.Services
{
    public class ShowingDetailService
    {
        public List<ShowingDetail> GetShowingDetails()
        {
            using (var repo = new Repository())
            {
                return repo.Details.ToList();
            }
        }

        public ShowingDetail GetShowingDetailById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Details.FirstOrDefault(h => h.ShowingID == id) ?? new ShowingDetail();
            }
        }

        public void UpdateShowingDetail(ShowingDetail showingDetail)
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