using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.CenterModels
{
    public class CenterCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        public States State { get; set; }
        public string Country { get; set; }
    }
}
