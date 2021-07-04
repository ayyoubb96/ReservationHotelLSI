using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsi_Hotel_Management.Model
{
    class Reservationn

    {
        public int Num { get; set; }
        public string clientn { get; set; }
        public int roomn { get; set; }
        public DateTime datein { get; set; }
        public DateTime dateout { get; set; }

        public Reservationn()
        {

        }

        public Reservationn(int num, string name, int room, DateTime di, DateTime doo)
        {
            this.Num = num;
            this.clientn = name;
            this.roomn = room;
            this.datein = di;
            this.dateout = doo;
        }


    }
}
