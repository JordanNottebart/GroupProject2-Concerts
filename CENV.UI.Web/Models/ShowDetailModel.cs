using CENV_JMH.DO;

namespace CENV.UI.Web.Models
{
    public class ShowDetailModel
    {
        public Showing TheShow{ get; set; }
        public List<ShowingInstance>? TheInstances { get; set; }

    }
}
