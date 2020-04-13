using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RatingModels
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int MyRating { get; set; }
        public string Description { get; set; }
        public bool IsUserOwned { get; set; }

    }
}
