using Sangha.Data;
using Sangha.Models.RatingModels.Retreat;
using Sangha.Models.TalkModels;
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
        public int RetreatId { get; set; }
        [Display(Name = "Retreat Name")]
        public string RetreatName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime RetreatDate { get; set; }

        [Display(Name = "Length of Retreat(days)")]
        public int RetreatLength { get; set; }
        public string Description { get; set; }


        [Display(Name = "Teacher(s)")]
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<TalkListItem> Talks { get; set; } = new List<TalkListItem>();
        public List<RetreatRatingListItem> Ratings { get; set; } = new List<RetreatRatingListItem>();

        public int? CenterId { get; set; }
        public string CenterName { get; set; }
        public Center Center { get; set; }
    }
}
