//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysCom.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actualizaciones
    {
        public int ID { get; set; }
        public int ID_recepcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Actualizacion { get; set; }
    
        public virtual recepcion recepcion { get; set; }
    }
}
