using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.Identity
{
    public class ApplicationUserDevice  
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(500)"))]
        public string PushNotificationProvider { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(500)"))]
        public string DeviceId { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(1000)"))]
        public string PushNotificationToken { get; set; }

        public bool Active { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
