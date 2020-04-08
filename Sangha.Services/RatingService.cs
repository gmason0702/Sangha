using Sangha.Data;
using Sangha.Models.RatingModels.Center;
using Sangha.Models.RatingModels.Retreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }
        //Rate a retreat
        public bool CreateRetreatRating(RetreatRatingCreate model)
        {
            var entity = new RetreatRating
            {
                Description = model.Description,
                RetreatId = model.RetreatId,
                MyRating = model.MyRating,
                UserId = _userId.ToString()
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Rate a center
        public bool CreateCenterRating(CenterRatingCreate model)
        {
            var entity = new CenterRating
            {
                Description = model.Description,
                CenterId = model.CenterId,
                MyRating = model.MyRating,
                VisitDate=model.VisitDate,
                UserId = _userId.ToString()
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
