using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RatingModels.Retreat
{
    public class RetreatRatingListItem : RatingListItem
    {
        public int? RetreatId { get; set; }
        public string RetreatName { get; set; }
    }
}
