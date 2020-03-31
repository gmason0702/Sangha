using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";


        //[ForeignKey(nameof(Talks))]
        //public int? TalkId { get; set; }
        public virtual ICollection<Talk> Talks { get; set; }

        //[ForeignKey(nameof(Retreats))]
        //public int? RetreatId { get; set; }
      //  public virtual ICollection<Retreat> Retreats { get; set; }

        //[ForeignKey(nameof(Centers))]
        //public int? CenterId { get; set; }
       // public virtual ICollection<Center> Centers { get; set; }
    }
}
