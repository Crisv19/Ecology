using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Shared.Entities
{
    public class Storage
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public int Cantidad { get; set; }

        public string TypRecicl {  get; set; }
        
        public int LeaderId { get; set; }

        public Leader Leader { get; set; }
    }
}
