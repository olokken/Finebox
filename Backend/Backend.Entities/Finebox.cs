using System;
using System.Collections.Generic;

namespace Backend.Entities
{
    public class Finebox
    {
        public Finebox()
        {
            Admins = new List<User>();
            Participants = new List<User>();
            Fines = new List<Fine>();
        }

        public Finebox(string fineBoxId, string name, string code, string paymentDescription, List<User> admins, List<User> participants, List<Fine> fines)
        {
            FineBoxId = fineBoxId;
            Name = name;
            Code = code;
            PaymentDescription = paymentDescription;
            Admins = admins;
            Participants = participants;
            Fines = fines;
        }

        public string FineBoxId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PaymentDescription { get; set; }
        public virtual List<User> Admins { get; set; }
        public virtual List<User> Participants { get; set; }
        public virtual List<Fine> Fines { get; set; }
    }
}

