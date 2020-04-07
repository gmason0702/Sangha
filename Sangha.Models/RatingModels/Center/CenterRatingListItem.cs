using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RatingModels.Center
{
    public class CenterRatingListItem : RatingListItem
    {
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
