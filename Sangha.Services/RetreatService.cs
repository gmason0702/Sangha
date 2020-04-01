using Sangha.Data;
using Sangha.Models.RetreatModels;
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
                    //CenterName = model.Center.Name
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
                        .Retreats
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RetreatListItem
                                {
                                    RetreatId=e.RetreatId,
                                    RetreatName = e.RetreatName,
                                    RetreatDate = e.RetreatDate,
                                    RetreatLength = e.RetreatLength,
                                    //TeacherId=e.Teachers.TeacherId,
                                    //Teacher=e.Teachers.
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
                return
                    new RetreatDetails
                    {
                        RetreatName = entity.RetreatName,
                        RetreatDate = entity.RetreatDate,
                        RetreatLength = entity.RetreatLength,
                        //Teacher = entity.Teacher,
                        CenterId=entity.CenterId,
                        CenterName = entity.Centers.Name
                    };
            }
        }
        public bool UpdateRetreat(RetreatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Retreats
                        .Single(e => e.CenterId == model.RetreatId);
                entity.RetreatName = model.RetreatName;
                entity.RetreatDate = model.RetreatDate;
                entity.RetreatLength = model.RetreatLength;

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
