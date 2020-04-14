using Sangha.Data;
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
    public enum States
    {
        [Description("Alabama")]
        AL,
        [Description("Alaska")]
        AK,
        [Description("Arkansas")]
        AR,
        [Description("Arizona")]
        AZ,
        [Description("California")]
        CA,
        [Description("Colorado")]
        CO,
        [Description("Connecticut")]
        CT,
        [Description("D.C.")]
        DC,
        [Description("Delaware")]
        DE,
        [Description("Florida")]
        FL,
        [Description("Georgia")]
        GA,
        [Description("Hawaii")]
        HI,
        [Description("Iowa")]
        IA,
        [Description("Idaho")]
        ID,
        [Description("Illinois")]
        IL,
        [Description("Indiana")]
        IN,
        [Description("Kansas")]
        KS,
        [Description("Kentucky")]
        KY,
        [Description("Louisiana")]
        LA,
        [Description("Massachusetts")]
        MA,
        [Description("Maryland")]
        MD,
        [Description("Maine")]
        ME,
        [Description("Michigan")]
        MI,
        [Description("Minnesota")]
        MN,
        [Description("Missouri")]
        MO,
        [Description("Mississippi")]
        MS,
        [Description("Montana")]
        MT,
        [Description("North Carolina")]
        NC,
        [Description("North Dakota")]
        ND,
        [Description("Nebraska")]
        NE,
        [Description("New Hampshire")]
        NH,
        [Description("New Jersey")]
        NJ,
        [Description("New Mexico")]
        NM,
        [Description("Nevada")]
        NV,
        [Description("New York")]
        NY,
        [Description("Oklahoma")]
        OK,
        [Description("Ohio")]
        OH,
        [Description("Oregon")]
        OR,
        [Description("Pennsylvania")]
        PA,
        [Description("Rhode Island")]
        RI,
        [Description("South Carolina")]
        SC,
        [Description("South Dakota")]
        SD,
        [Description("Tennessee")]
        TN,
        [Description("Texas")]
        TX,
        [Description("Utah")]
        UT,
        [Description("Virginia")]
        VA,
        [Description("Vermont")]
        VT,
        [Description("Washington")]
        WA,
        [Description("Wisconsin")]
        WI,
        [Description("West Virginia")]
        WV,
        [Description("Wyoming")]
        WY
    }

public class Center
    {
        [Key]
        public int CenterId { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Talk> Talks { get; set; } //NonRetreatTalks

        public virtual ICollection<Retreat> Retreats { get; set; } = new List<Retreat>();

        //public virtual ICollection<RetreatRating> Ratings { get; set; }
        [DisplayName("Average Rating")]
        public double AvgRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                {
                    var avg = (double)Ratings.Sum(rating => rating.MyRating) / Ratings.Count;
                    if (avg >= 1 && avg < 1.5)
                    {
                        return avg = 1;
                    }
                    else if (avg >= 1.5 && avg <2)
                    {
                        return avg = 1.5;
                    }
                    else if (avg >= 2 && avg < 2.5)
                    {
                        return avg = 2;
                    }
                    else if (avg >= 2.5 && avg < 3)
                    {
                        return avg = 2.5;
                    }
                    else if (avg >= 3 && avg < 3.5)
                    {
                        return avg = 3;
                    }
                    else if (avg >= 3.5 && avg < 4)
                    {
                        return avg = 3.5;
                    }
                    else if (avg >= 4 && avg <4.5)
                    {
                        return avg = 4;
                    }
                    else if (avg >= 4.5 && avg <5)
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
        public virtual ICollection<CenterRating> Ratings { get; set; } = new List<CenterRating>();

    }
}
