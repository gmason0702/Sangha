using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        [Range(1,5)]
        public int MyRating { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } // check to see if this should be a string
        public virtual ApplicationUser User { get; set; }
    }

    public class RetreatRating : Rating
    {
        [ForeignKey(nameof(Retreat))]
        public int? RetreatId { get; set; }
        public virtual Retreat Retreat { get; set; }
    }

    public class CenterRating : Rating
    {
        public DateTime VisitDate { get; set; }

        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; }
        public virtual Center Center { get; set; }
    }
}

