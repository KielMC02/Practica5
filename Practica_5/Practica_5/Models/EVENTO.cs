//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica_5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EVENTO
    {
        public int ID_evento { get; set; }
        [Required(ErrorMessage = "LA FECHA ES REQUERIDA")]
        public Nullable<System.DateTime> fecha { get; set; }
        [Required(ErrorMessage ="LA HORA ES REQUERIDA")]
        public string hora { get; set; }
        [Required(ErrorMessage ="LA DESCRIPCION ES REQUERIDA")]
        public string descripcion { get; set; }
    }
}
