using System;
using System.Collections.Generic;

namespace Backend.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<FineBox> FineBoxes { get; set; }

    }
}
