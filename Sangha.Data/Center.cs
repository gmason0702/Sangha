using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Center
    {
        [Key]
        public int CenterId { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [ForeignKey(nameof(Talks))]
        public int TalkId { get; set; }//maybe don't need
        public virtual ICollection<Talk> Talks { get; set; }

        [ForeignKey(nameof(Teachers))]
        public int TeacherId { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        [ForeignKey(nameof(Retreats))]
        public int RetreatId { get; set; }
        public virtual ICollection<Retreat> Retreats { get; set; }

        //public virtual ICollection<RetreatRating> Ratings { get; set; }
        public double AvgRating { get; set; }
    }
}
