using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransmissionAPI.Data
{
    public class RoleDashboards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int? DashboardId { get; set; }
        public string FileControl { get; set; }
        public Nullable<bool> PermitAccess { get; set; }
    }
}
