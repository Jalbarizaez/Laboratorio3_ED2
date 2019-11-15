using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3
{
    public class Pizza
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string[] ingredientes { get; set; }
        public string masa { get; set; }
        public string tamaño { get; set; }
        public int porciones { get; set; }
        public bool extraQueso { get; set; }
    }
}
