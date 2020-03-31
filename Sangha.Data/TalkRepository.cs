using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sangha.Data
{
    public class TalkRepository
    {

        public static List<Talk> GetTalkList()
        {
            List<Talk> talk_list = new List<Talk>();
            talk_list.Add(new Talk()
            {
                TalkId = 12312,
                Name = "A guided meditation for beginners",
                Description = "A short guided meditation beginning with a body scan, inviting any tension held in various parts of the body to release, then a few minutes of mindfulness of breathing suitable for complete beginners.",
                TeacherId = 3,
                TalkLength = new TimeSpan(0, 17, 16),
                TalkDate = new DateTime(2020, 3, 28),
                Topic = "beginners guided",
                IsGuided = true,
                CenterId = 3
            }) ;
            return talk_list;
        }
    }
}
