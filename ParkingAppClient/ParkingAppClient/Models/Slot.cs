using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppClient.Models
{
    public class Slot
    {
       public int Id { get; set; }
       
        public Nullable<int> PlaceId { get; set; }
      
        public int FreeSlots { get; set; }
    }
}
