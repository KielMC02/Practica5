//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica_5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ESTUDIANTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTUDIANTE()
        {
            this.ESTUDIANTES_MATERIAS = new HashSet<ESTUDIANTES_MATERIAS>();
        }
    
        public int ID_estudiante { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Edad")]
        public Nullable<int> edad { get; set; }
        [Display(Name = "Genero")]
        public string sexo { get; set; }
        [Display(Name = "Carrera")]
        public string carrera { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTUDIANTES_MATERIAS> ESTUDIANTES_MATERIAS { get; set; }
    }
}
