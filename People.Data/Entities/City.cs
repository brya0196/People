using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdProvince { get; set; }
        public Province Province { get; set; }

        public List<Residence> Residences { get; set; }
    }
}
