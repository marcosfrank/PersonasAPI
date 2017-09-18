using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonasAPI.Models
{
    public class Persona
    {
        #region Properties

        public string Direccion { get; set; }

        public int Edad { get; set; }

        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        #endregion Properties
    }
}