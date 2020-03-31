using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Talk
    {
        [Key]
        public int TalkID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public TimeSpan TalkLength { get; set; }
        public DateTime TalkDate { get; set; }
        public string Topic { get; set; }
        public bool IsGuided { get; set; }

        [ForeignKey(nameof(Retreat))]
        public int RetreatId { get; set; }
        public virtual Retreat Retreat { get; set; }

        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; }
        public virtual Center Center { get; set; }
    }
}
