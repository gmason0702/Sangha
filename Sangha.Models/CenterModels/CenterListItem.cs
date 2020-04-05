using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.CenterModels
{
    public class CenterListItem
    {
        [DisplayName("ID")]
        public int CenterId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public ICollection<Retreat> Retreats { get; set; }

        //public virtual ICollection<RetreatRating> Ratings { get; set; }
        public double AvgRating
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    double sum = 0;
                    double count = 0;
                    foreach (CenterRating rating in ctx.Ratings)
                    {
                        if (rating.CenterId == CenterId)
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
