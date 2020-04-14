using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DCamara
    {
        public int id { get; set; }
 
        public String fullname { get; set; }
        
        public String email { get; set; }
        
        public String addres { get; set; }
        
        public String phone { get; set; }
    }
}
