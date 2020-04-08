using Sangha.Data;
using Sangha.Models.CenterModels;
using Sangha.Models.RatingModels.Center;
using Sangha.Models.RetreatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class CenterService
    {
        private readonly Guid _userId;

        public CenterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCenter(CenterCreate model)
        {
            var entity =
                new Center()
                {
                    Name=model.Name,
                    City=model.City,
                    State=model.State,
                    Country=model.Country
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Centers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CenterListItem> GetCenters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Centers.ToList()
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CenterListItem
                                {
                                    CenterId=e.CenterId,
                                    Name=e.Name,
                                    City=e.City,
                                    State=e.State,
                                    Retreats=e.Retreats,
                                    AvgRating=e.AvgRating                                 
                                }
                        );

                return query.ToArray();
            }
        }

        public CenterDetails GetCenterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Centers
                        .Single(e => e.CenterId == id);
                return
                    new CenterDetails
                    {
                        CenterId = entity.CenterId,
                        Name = entity.Name,
                        City = entity.City,
                        State = entity.State,
                        Retreats = entity.Retreats.Select(retreat => new RetreatListItem
                        {
                            RetreatId = retreat.RetreatId,
                            RetreatName = retreat.RetreatName,
                            RetreatDate = retreat.RetreatDate,
                            RetreatLength = retreat.RetreatLength,
                        }).ToList(),
                        Ratings = entity.Ratings.Select(r => new CenterRatingListItem
                        {
                            RatingId = r.RatingId,
                            CenterId = r.CenterId,
                            CenterName = entity.Name,
                            Description = r.Description,
                            IsUserOwned = r.UserId == _userId.ToString()
                        }).ToList()
                    };
            }
        }
        public bool UpdateCenter(CenterEdit model)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Centers
                        .Single(e => e.CenterId == model.CenterId);
                entity.Name = model.Name;
                entity.City = model.City;
                entity.State = model.State;
                entity.Country = model.Country;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCenter(int centerId)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Centers
                        .Single(e => e.CenterId == centerId);
                ctx.Centers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
