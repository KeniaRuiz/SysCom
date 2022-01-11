using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SysCom.Models
{
    [MetadataType(typeof(SoporteMetaData))]
    public partial class soporte
    {
    }

    public class SoporteMetaData
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public int Cliente { get; set; }
        public string Actividad { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public System.DateTime Fecha_inicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public Nullable<System.DateTime> Fecha_Fin { get; set; }
        public int Empleado_recepcion { get; set; }
        public Nullable<int> Empleado_tecnico { get; set; }
        public int Estatus { get; set; }

        public virtual cEstatus cEstatus { get; set; }
        public virtual clientes clientes { get; set; }
        public virtual empleados empleados { get; set; }
        public virtual empleados empleados1 { get; set; }
    }

}