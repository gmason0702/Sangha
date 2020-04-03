using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RetreatModels
{
    public class RetreatListItem
    {
        public int RetreatId { get; set; }
        [Display(Name = "Retreat Name")]
        public string RetreatName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime RetreatDate { get; set; }
        [Display(Name = "Length of Retreat")]
        public int RetreatLength { get; set; }
        [Display(Name = "Teacher(s)")]

        public int TeacherId { get; set; }
        public string Teacher { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public double AvgRating
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    double sum = 0;
                    double count = 0;
                    foreach (RetreatRating rating in ctx.Ratings)
                    {
                        if (rating.RetreatId == RetreatId)
                        {
                            sum += rating.MyRating;
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        return 0;
                    }
                    double average = sum / count;
                    return average;
                }
            }
        }
    }
}
