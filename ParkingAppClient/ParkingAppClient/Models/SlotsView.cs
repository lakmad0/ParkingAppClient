using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppClient.Models
{
    public class SlotsView
    {
        public int Id { get; set; }
       
        public string PlaceName { get; set; }
        
        public Nullable<int> PlaceId { get; set; }
      
        public int FreeSlots { get; set; }
    }
}
