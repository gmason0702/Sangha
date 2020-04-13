using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.SitTrackerModels
{
    public class SitTrackerCreate
    {
        [Required]
        public int SitId { get; set; }
        [Required]
        [DisplayName("Date of Sit")]
        public DateTimeOffset SitDate { get; set; }

        [DisplayName("Length of Sit")]
        public TimeSpan SitLength { get; set; }
        [DisplayName("Type of Sit")]
        public SitType TypeOfSit { get; set; }

        public string Note { get; set; }
        public string SitLink { get; set; }
    }
}
