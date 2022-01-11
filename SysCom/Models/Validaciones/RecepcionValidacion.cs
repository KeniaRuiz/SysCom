using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SysCom.Models
{
    [MetadataType(typeof(RecepcionMetaData))]
    public partial class recepcion
    {
    }

    public class RecepcionMetaData
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public int Cliente { get; set; }
        public string Problema { get; set; }
        public string Equipo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public System.DateTime Fecha_inicio { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha_fin { get; set; }
        public int Empleado_recepcion { get; set; }
        public Nullable<int> Empleado_tecnico { get; set; }
        public int Estatus { get; set; }
        public byte[] imagen { get; set; }
    }

}

