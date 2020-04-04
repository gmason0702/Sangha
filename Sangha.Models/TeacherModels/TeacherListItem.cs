using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TeacherModels
{
    public class TeacherListItem
    {
        [DisplayName("Teacher Id")]
        public int TeacherId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Talk> Talks { get; set; }
        public ICollection<Retreat> Retreats { get; set; }
        public ICollection<Center> Centers { get; set; }
    }
}
