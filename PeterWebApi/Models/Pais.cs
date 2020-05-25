﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeterWebApi.Models
{
    public class Pais
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public List<Provincia> Provincias { get; set; }
    }
}
