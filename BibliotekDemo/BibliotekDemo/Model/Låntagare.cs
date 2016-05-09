using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekDemo.Model
{
    public class Låntagare
    {
        public int Id { get; set; }
        public string Namn { get; set; }

        public virtual IList<Lån> Lån { get; set; }
    }
}
