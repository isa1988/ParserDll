using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParseDLLWeb.Models
{
    public class FileDllModel
    {
        [Required(ErrorMessage = "Path is null")]
        [DisplayName("Path to directive")]
        public string Path { get; set; }

        public string Result { get; set; }
    }
}
