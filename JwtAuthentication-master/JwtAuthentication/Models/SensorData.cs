using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Model
{
    public class SensorData
    {
        [Key]
        public string SensorId { get; set; }

        [ForeignKey("Device")]
        public string DeviceId { get; set; }
        public Device Device { get; set; }

        public DateTime TimeStamp { get; set; }

        public float TopOfLeftSensor { get; set; }
        //public float TopOfRightSensor { get; set; }
        //public float BottomOfRightSensor { get; set; }
        //public float BottomOfLeftSensor { get; set; }
       
        //public float SeatLeftSensor { get; set; }
        //public float SeatRightSensor { get; set; }

    }
}
