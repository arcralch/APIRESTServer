using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clienteRest.Models
{
    public class mvcProductModel
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<int> PRECIO { get; set; }
        public Nullable<int> EXISTENCIAS { get; set; }
    }
}