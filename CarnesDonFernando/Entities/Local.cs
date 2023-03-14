using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Local
    {
        public Local()
        {
            MensajesContactos = new HashSet<MensajesContacto>();
        }

        public int IdLocal { get; set; }
        public string NombreLocal { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Horario { get; set; } = null!;
        public string UrlImg { get; set; } = null!;

        public virtual ICollection<MensajesContacto> MensajesContactos { get; set; }
    }
}
