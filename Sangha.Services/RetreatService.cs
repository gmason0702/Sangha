using Sangha.Data;
using Sangha.Models.RatingModels.Retreat;
using Sangha.Models.RetreatModels;
using Sangha.Models.TalkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class RetreatService
    {
        private readonly Guid _userId;

        public RetreatService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRetreat(RetreatCreate model)
        {
            var entity =
                new Retreat()
                {
                    RetreatName = model.RetreatName,
                    RetreatDate = model.RetreatDate,
                    RetreatLength = model.RetreatLength,
                    //TeacherId = model.TeacherId,
                    CenterId=model.CenterId,
                    Description=model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Retreats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RetreatListItem> GetRetreats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Retreats.ToList()
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RetreatListItem
                                {
                                    RetreatId=e.RetreatId,
                                    RetreatName = e.RetreatName,
                                    RetreatDate = e.RetreatDate,
                                    RetreatLength = e.RetreatLength,
                                    AvgRating=e.AvgRating                               
                                }
                        );
                return query.ToArray();
            }
        }

        public RetreatDetails GetRetreatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retreats
                        .Single(e => e.RetreatId == id);
                var model =
                    new RetreatDetails
                    {
                        RetreatName = entity.RetreatName,
                        RetreatDate = entity.RetreatDate,
                        RetreatLength = entity.RetreatLength,
                        //Teacher = entity.Teacher,
                        Description = entity.Description,
                        Talks = entity.Talks.Select(talk => new TalkListItem
                        {
                            TalkId = talk.TalkId,
                            Name=talk.Name,
                            IsGuided=talk.IsGuided,
                            TalkLink=talk.TalkLink,
                            Topic=talk.Topic,          
                        }).ToList(),
                        CenterId=entity.CenterId,
                        CenterName = entity.Centers.Name,
                        Ratings=entity.Ratings.Select(r=> new RetreatRatingListItem
                        {
                            RatingId=r.RatingId,
                            RetreatId=r.RetreatId,
                            RetreatName=entity.RetreatName,
                            Description=r.Description,
                            IsUserOwned=r.UserId==_userId.ToString()
                            
                        }).ToList()
                    };
                return model;
            }
        }

        public bool UpdateRetreat(RetreatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retreats
                        .Single(e => e.RetreatId == model.RetreatId);
                entity.RetreatName = model.RetreatName;
                entity.RetreatDate = model.RetreatDate;
                entity.RetreatLength = model.RetreatLength;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRetreat(int retreatId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retreats
                        .Single(e => e.RetreatId == retreatId);
                ctx.Retreats.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
