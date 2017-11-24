using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppClient.Models
{
    public class Place
    {        
        public int Id { get; set; }
        
        public string PlaceName { get; set; }
        
        public string Address { get; set; }
      
        public double Longitude { get; set; }
       
        public double Latitude { get; set; }
        
        public int MaxSlots { get; set; }
    }
}
