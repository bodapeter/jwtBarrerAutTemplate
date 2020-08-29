using JwtAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels
{
    public class SensorSetViewModel
    {
        public List<SensorData> Sensors { get; set; }
        public DateTime TimeStamp { get; set; }
        public Device Uid { get; set; }

    }
}
