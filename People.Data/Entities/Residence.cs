using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data.Entities
{
    public class Residence
    {
        public int Id { get; set; }
        public int IdCity { get; set; }
        public City City { get; set; }
        public int IdUser { get; set; }

        public List<Person> People { get; set; }
        public List<Service> Services { get; set; }
    }
}
