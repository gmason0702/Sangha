using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RatingModels.Center
{
    public class CenterRatingCreate
    {
        [Required]
        public int CenterId { get; set; }

        [Required]
        [Range(1, 5)]
        public int MyRating { get; set; }

        public string Description { get; set; }
        public DateTime VisitDate { get; set; }

    }
}
