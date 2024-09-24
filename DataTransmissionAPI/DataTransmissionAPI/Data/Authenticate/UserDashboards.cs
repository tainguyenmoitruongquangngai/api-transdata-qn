using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransmissionAPI.Data
{
    public class UserDashboards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int? DashboardId { get; set; }
        public string FileControl { get; set; }
        public Nullable<bool> PermitAccess { get; set; }
    }
}
