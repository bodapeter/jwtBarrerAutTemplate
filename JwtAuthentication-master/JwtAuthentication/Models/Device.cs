using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Model
{
    public class Device
    {
        [Key]
        public string DeviceId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
