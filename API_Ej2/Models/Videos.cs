using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Ej2.Models
{
    public class Videos
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public Cliente cli_ID { get; set; }
    }
}
