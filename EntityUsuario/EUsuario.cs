using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityUsuario
{
    public class EUsuario
    {
        public int id { get; set; }

        [DisplayName("NOMBRE")]
        public string nombre { get; set; }

        [DisplayName("APELLIDO PATERNO")]
        public string apellidop { get; set; }

        [DisplayName("APELLIDO MATERNO")]
        public string apellidom { get; set; }

        [DisplayName("FECHA DE NACIMIENTO")]
        public string fecha { get; set; }

        [DisplayName("EDAD")]
        public int edad { get; set; }

       



    }
}
