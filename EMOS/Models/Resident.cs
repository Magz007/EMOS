using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMOS.Models
{
    public class Resident
    {

        public int ID { get; set; }
        public int Roomnumber { get; set; }
        public string FnameInital { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string LOI { get; set; }

    }
}
