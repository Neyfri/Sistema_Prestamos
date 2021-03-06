//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login_Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class prestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prestamo()
        {
            this.pagos = new HashSet<pago>();
        }
    
        public int id { get; set; }
        public Nullable<int> cedula { get; set; }
        public Nullable<System.DateTime> fecha_soli { get; set; }
        public Nullable<System.DateTime> fecha_aprob { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<long> capital { get; set; }
        public Nullable<decimal> interes { get; set; }
        public Nullable<int> fiador_ced { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public Nullable<int> tipo_pago { get; set; }
        public Nullable<int> garantia { get; set; }
        public Nullable<int> periodo { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual fiador fiador { get; set; }
        public virtual garantia garantia1 { get; set; }
        public virtual tipo_pago tipo_pago1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pago> pagos { get; set; }
    }
}
