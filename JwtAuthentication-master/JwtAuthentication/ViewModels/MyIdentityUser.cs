using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels
{
    public class MyIdentityUser : IdentityUser
    {
        [Required]
        public double UserWeight { get; set; }

        public string DeviceID { get; set; }
    }
}
