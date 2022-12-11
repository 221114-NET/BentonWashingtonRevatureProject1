using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Tickets
    {
        public Tickets(int tickID, string tickType, double tickAmount, string tickDescription, string tickStatus, int userID) 
        {
            this.TickID = tickID;
            this.TickType = tickType;
            this.TickAmount = tickAmount;
            this.TickDescription = tickDescription;
            this.TickStatus = tickStatus;
            this.UserID = userID;
   
        }

        public int TickID { get; set; }
        public string TickType { get; set; }
        public double TickAmount  { get; set; }
        public string TickDescription { get; set; }
        public string TickStatus { get; set; }
        public int UserID { get; set; }

    }
}