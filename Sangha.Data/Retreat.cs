using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Retreat
    {
        [Key]
        [DisplayName("ID")]
        public int RetreatId { get; set; }

        [DisplayName("Retreat Name")]
        public string RetreatName { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        [DisplayName("Date of Retreat")]
        [DataType(DataType.Date)]
        public DateTime RetreatDate { get; set; }
        [DisplayName("Retreat Length(days)")]
        public int RetreatLength { get; set; }
        public string Description { get; set; }


        //[ForeignKey(nameof(Teacher))]
        //public int? TeacherId { get; set; }
        //public virtual ICollection<Teacher> Teacher { get; set; } = new List<Teacher>();

        //[ForeignKey(nameof(Talks))]
        //public int? TalkId { get; set; }
        [DisplayName("Average Rating")]
        public double AvgRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                {
                    var avg= (double)Ratings.Sum(rating => rating.MyRating) / Ratings.Count;
                    if (avg>=1 && avg<1.5)
                    {
                        return avg = 1;
                    }
                    else if (avg>=1.5 && avg<2)
                    {
                        return avg = 1.5;
                    }
                    else if (avg>=2 && avg<2.5)
                    {
                        return avg = 2;
                    }
                    else if (avg>=2.5 && avg<3)
                    {
                        return avg = 2.5;
                    }
                    else if (avg>=3 && avg<3.5)
                    {
                        return avg = 3;
                    }
                    else if (avg>=3.5 && avg<4)
                    {
                        return avg = 3.5;
                    }
                    else if (avg>=4 && avg<4.5)
                    {
                        return avg = 4;
                    }
                    else if (avg>=4.5 && avg<5)
                    {
                        return avg = 4.5;
                    }
                    else
                    {
                        return avg = 5;
                    }
                  
                }
                return 0;
            }
        }
        public virtual ICollection<RetreatRating> Ratings { get; set; } = new List<RetreatRating>();
        public virtual ICollection<Talk> Talks { get; set; } = new List<Talk>();
       
        //public int? TeacherId { get; set; }
        //public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        [ForeignKey(nameof(Centers))]
        public int? CenterId { get; set; }
        public virtual Center Centers { get; set; }
        //public virtual ICollection<RetreatRating> Ratings { get; set; }

    }
}
