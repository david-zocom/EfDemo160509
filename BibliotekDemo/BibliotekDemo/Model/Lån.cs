using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekDemo.Model
{
    public class Lån
    {
        public int Id { get; set; }

        public bool Tillbakalämnad { get; set; }

        public virtual Låntagare Låntagare { get; set; }

        public virtual IList<Bok> Böcker { get; set; }
    }
}
