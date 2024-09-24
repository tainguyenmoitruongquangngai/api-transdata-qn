using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransmissionAPI.Data
{
    public class Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public int? DashboardId { get; set; }
        public int? FunctionId { get; set; }
        public string FunctionName { get; set; } = string.Empty;
        public string FunctionCode { get; set; } = string.Empty;

    }
}
