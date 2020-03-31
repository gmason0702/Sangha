using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RetreatModels
{
    public class RetreatDetails
    {
        [Display(Name = "Retreat Name")]
        public string RetreatName { get; set; }
        [Display(Name = "Start Date")]
        public DateTimeOffset RetreatDate { get; set; }
        [Display(Name = "Length of Retreat")]
        public TimeSpan RetreatLength { get; set; }
        [Display(Name = "Teacher(s)")]
        public ICollection<Teacher> Teacher { get; set; }
        public ICollection<Talk> Talk { get; set; }
        public Center Center { get; set; }
    }
}
