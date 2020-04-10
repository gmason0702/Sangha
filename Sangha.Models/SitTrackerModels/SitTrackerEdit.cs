using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.SitTrackerModels
{
    public class SitTrackerEdit
    {
        public int? SitId { get; set; }

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
