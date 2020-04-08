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
        [DisplayName("Average Rating")]
        public double AvgRating { get; set; }
        
    }
}
