using Sangha.Data;
using Sangha.Models.TalkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class TalkService
    {
        private readonly Guid _userId;

        public TalkService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTalk(TalkCreate model)
        {
            var entity =
                new Talk()
                {
                    //OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    TeacherId = model.TeacherId,
                    TalkLength = model.TalkLength,
                    TalkDate = model.TalkDate,
                    RetreatId = model.RetreatId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Talks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TalkListItem> GetTalks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Talks
                        // .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TalkListItem
                                {
                                    TalkId = e.TalkId,
                                    Name = e.Name,
                                    Teacher = e.Teacher,
                                    Topic = e.Topic,
                                    TalkLength = e.TalkLength,
                                    RetreatId = e.RetreatId
                                }
                            );
                return query.ToArray();

            }
        }
        public TalkDetail GetTalkById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Talks
                        .Single(e => e.TalkId == Id);
                return
                     new TalkDetail
                     {
                         TalkId = entity.TalkId,
                         Name = entity.Name,
                         Teacher = entity.Teacher,
                         Topic = entity.Topic,
                         Description = entity.Description,
                         TalkLength = entity.TalkLength,
                         TalkDate = entity.TalkDate,
                         IsGuided = entity.IsGuided

                     };
            }
        }
    }
}
