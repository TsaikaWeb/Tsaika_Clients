using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Tsaika_Clients.Models
{
    public class Clients
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Eng_Name { get; set; }
        public string Gender { get; set; }


    }
}