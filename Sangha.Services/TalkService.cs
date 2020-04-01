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
                    Topic=model.Topic,
                    TeacherId = model.TeacherId,
                    //Teachers = model.Teacher,
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
                                    TeacherId=e.TeacherId,
                                    Teacher = e.Teachers.FullName,
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
                         Topic = entity.Topic,
                         Description = entity.Description,
                         TalkLength = entity.TalkLength,
                         TalkDate = entity.TalkDate,
                         IsGuided = entity.IsGuided,
                         TeacherId = entity.TeacherId,
                         Teacher=entity.Teachers.FullName
                     };
            }
        }
        public bool UpdateTalk(TalkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Talks
                        .Single(e => e.TalkId == model.TalkId);
                entity.Name = model.Name;
                entity.TeacherId = model.TeacherId;
                //entity.Teacher = model.Teachers.FullName;
                entity.Topic = model.Topic;
                entity.TalkLength = model.TalkLength;
                entity.TalkDate = model.TalkDate;
                entity.IsGuided = model.IsGuided;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTalk(int talkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Talks
                        .Single(e => e.TalkId == talkId);
                ctx.Talks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
