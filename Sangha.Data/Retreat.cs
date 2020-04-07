using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("ID")]
        public int RetreatId { get; set; }

        [DisplayName("Retreat Name")]
        public string RetreatName { get; set; }

        [DisplayName("Date of Retreat")]
        [DataType(DataType.Date)]
        public DateTime RetreatDate { get; set; }
        [DisplayName("Retreat Length(days)")]
        public int RetreatLength { get; set; }
        public string Description { get; set; }


        //[ForeignKey(nameof(Teacher))]
        //public int TeacherId { get; set; }
        // public virtual ICollection<Teacher> Teacher { get; set; }

        //[ForeignKey(nameof(Talks))]
        //public int? TalkId { get; set; }
        [DisplayName("Average Rating")]
        public double AvgRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                {
                    return (double)Ratings.Sum(rating => rating.MyRating) / Ratings.Count;
                }
                return 0;
            }
        }
        public virtual ICollection<RetreatRating> Ratings { get; set; } = new List<RetreatRating>();
        public virtual ICollection<Talk> Talks { get; set; } = new List<Talk>();
        public int? TeacherId { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        [ForeignKey(nameof(Centers))]
        public int? CenterId { get; set; }
        public virtual Center Centers { get; set; }
        //public virtual ICollection<RetreatRating> Ratings { get; set; }

    }
}
