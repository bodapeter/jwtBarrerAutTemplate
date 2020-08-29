using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Model
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("Device")]
        public string DeviceID { get; set; }
        public Device Device { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double High { get; set; }
        public double Weigh { get; set; }

    }
}
