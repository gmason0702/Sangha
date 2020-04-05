using Sangha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.CenterModels
{
    public class CenterEdit
    {
        public int CenterId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Country { get; set; }
    }
}
