using Microsoft.AspNetCore.Identity;

namespace DataTransmissionAPI.Data
{
    public partial class AspNetUsers : IdentityUser
    {
        public string PasswordSalt { get; set; }
        public string FullName { get; set; }
        public string IdHuyen { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedUser { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
