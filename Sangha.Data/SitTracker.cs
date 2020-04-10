using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public enum SitType { Guided, Concentration, BodyScan, Noting, Metta, Compassion, Reflection, Awareness, Contemplation}
    public class SitTracker
    {

        [Key]
        public int SitId { get; set; }
        [Required]
        public DateTimeOffset SitDate { get; set; }
        public TimeSpan SitLength { get; set; }
        public string Note { get; set; }
        public string SitLink { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
