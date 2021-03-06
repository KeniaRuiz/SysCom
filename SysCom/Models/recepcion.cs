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
    
    public partial class recepcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recepcion()
        {
            this.Actualizaciones = new HashSet<Actualizaciones>();
        }
    
        public int ID { get; set; }
        public int Cliente { get; set; }
        public string Problema { get; set; }
        public string Equipo { get; set; }
        public System.DateTime Fecha_inicio { get; set; }
        public System.DateTime Fecha_fin { get; set; }
        public int Empleado_recepcion { get; set; }
        public Nullable<int> Empleado_tecnico { get; set; }
        public int Estatus { get; set; }
        public byte[] imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actualizaciones> Actualizaciones { get; set; }
        public virtual cEstatus cEstatus { get; set; }
        public virtual clientes clientes { get; set; }
        public virtual empleados empleados { get; set; }
        public virtual empleados empleados1 { get; set; }
    }
}
