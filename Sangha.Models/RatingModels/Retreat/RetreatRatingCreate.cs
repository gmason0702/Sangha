using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RatingModels.Retreat
{
    public class RetreatRatingCreate
    {
        [Required]
        public int RetreatId { get; set; }

        [Required]
        [Range(1,5)]
        public int MyRating { get; set; }

        public string Description { get; set; }


    }
}
