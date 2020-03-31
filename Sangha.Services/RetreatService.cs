using Sangha.Data;
using Sangha.Models.RetreatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    //public class RetreatService
    //{
    //    private readonly Guid _userId;

    //    public RetreatService(Guid userId)
    //    {
    //        _userId = userId;
    //    }

    //    public bool CreateRetreat(RetreatCreate model)
    //    {
    //        var entity =
    //            new Retreat()
    //            {
    //                RetreatName = model.RetreatName,
    //                RetreatDate = model.RetreatDate,
    //                RetreatLength = model.RetreatLength,
    //                Teacher = model.Teacher,
    //                Center = model.Center
    //            };

    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            ctx.Retreats.Add(entity);
    //            return ctx.SaveChanges() == 1;
    //        }
    //    }
    //    public IEnumerable<RetreatListItem> GetRetreats()
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var query =
    //                ctx
    //                    .Retreats
    //                    //.Where(e => e.OwnerId == _userId)
    //                    .Select(
    //                        e =>
    //                            new RetreatListItem
    //                            {
    //                                RetreatName = e.RetreatName,
    //                                RetreatDate = e.RetreatDate,
    //                                RetreatLength = e.RetreatLength,
    //                                Teacher = e.Teacher,
    //                            }
    //                    );

    //            return query.ToArray();
    //        }
    //    }

    //    public RetreatDetails GetRetreatById(int id)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .Retreats
    //                    .Single(e => e.RetreatId == id);
    //            return
    //                new RetreatDetails
    //                {
    //                    RetreatName = entity.RetreatName,
    //                    RetreatDate = entity.RetreatDate,
    //                    RetreatLength = entity.RetreatLength,
    //                    Teacher = entity.Teacher,
    //                    Center=entity.Center
    //                };
    //        }
    //    }
    //}
}
