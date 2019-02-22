using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data.Entities
{
    public class KindService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Service> Services { get; set; }
    }
}
