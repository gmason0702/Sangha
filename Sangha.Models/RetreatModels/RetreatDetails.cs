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
        public DateTime RetreatDate { get; set; }

        [Display(Name = "Length of Retreat")]
        public int RetreatLength { get; set; }
        public string Description { get; set; }


        [Display(Name = "Teacher(s)")]
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Talk> Talks { get; set; }
        public int? CenterId { get; set; }
        public string CenterName { get; set; }
        public Center Center { get; set; }
    }
}
