using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekDemo.Model
{
    public class Bok
    {
        public int BokId { get; set; }
        public string Titel { get; set; }

        public virtual IList<Genre> Genres { get; set; }

        public virtual Lån Lån { get; set; }
    }
}
