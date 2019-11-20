using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_5.Models
{
    public class CustomerModel
    {
        public  int ID { get; set; }
        public  string Nombre { get; set; }

        public  string Apellido  { get; set; }
        public  string Telefono  { get; set; }

        public string Direccion { get; set; }
        public int Edad { get; set; }

        public string Sexo { get; set; }

        
    }
}