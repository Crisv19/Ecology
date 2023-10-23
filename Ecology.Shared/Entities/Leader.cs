using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Shared.Entities
{
    public class Leader
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string CellPhon {  get; set; }

        public string Identification { get; set; }

        public string Address { get; set; }

        public int NumberRecycler {  get; set; }

        public int CollectorId { get; set; }

        public Collector Collector { get; set; }
        

    }
}
