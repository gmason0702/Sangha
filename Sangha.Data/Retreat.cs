using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Retreat
    {
        [Key]
        public int RetreatId { get; set; }
        public string RetreatName { get; set; }
        public DateTimeOffset RetreatDate { get; set; }
        public TimeSpan RetreatLength { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }

        [ForeignKey(nameof(Talk))]
        public int TalkId { get; set; }
        public virtual ICollection<Talk> Talk { get; set; }

        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }
        //public virtual ICollection<RetreatRating> Ratings { get; set; }
        public double AvgRating { get; set; }
    }
}
