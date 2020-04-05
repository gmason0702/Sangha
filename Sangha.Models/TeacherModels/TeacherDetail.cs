using Sangha.Data;
using Sangha.Models.TalkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TeacherModels
{
    public class TeacherDetail
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        //public int TalkId { get; set; }
        //public string Name { get; set; }

        //public string Topic { get; set; }
        //public DateTime TalkLength { get; set; }
        //public int RetreatId { get; set; }
        public List<TalkDetail> Talks { get; set; }

        public ICollection<Retreat> Retreats { get; set; }

        public ICollection<Center> Centers { get; set; }
    }
}
