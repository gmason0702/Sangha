using Sangha.Data;
using Sangha.Models.SitTrackerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class SitTrackerService
    {
        private readonly Guid _userId;
        public SitTrackerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSit(SitTrackerCreate model)
        {
            var entity =
                new SitTracker()
                {
                    UserId=_userId.ToString(),
                    SitDate = DateTimeOffset.Now,
                    SitLength = model.SitLength,
                    Note = model.Note,
                    TypeOfSit = model.TypeOfSit,
                    SitLink = model.SitLink
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SitTrackerListItem> GetSits()
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sits.Select(e => new SitTrackerListItem
                        {
                            SitId=e.SitId,
                            SitLength = e.SitLength,
                            Note=e.Note,
                            SitDate = e.SitDate,
                            TypeOfSit = e.TypeOfSit,                         
                            SitLink=e.SitLink
                        });
                return query.ToArray();
            }
        }
        public SitTrackerDetail GetSitById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sits.Single(e => e.SitId == id && e.UserId == _userId.ToString());
                return new SitTrackerDetail
                {
                    SitDate = entity.SitDate,
                    SitLength = entity.SitLength,
                    Note = entity.Note,
                    TypeOfSit = entity.TypeOfSit,
                    SitLink = entity.SitLink
                };
            }
        }
        public SitTrackerDetail GetSitTimerById(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity = ctx.Sits.Single(e => e.SitId == id);
                return new SitTrackerDetail
                {
                    SitId = entity.SitId,
                    SitLength = entity.SitLength
                };
            }
        }
        public bool UpdateSit(SitTrackerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sits.Single(e => e.SitId == model.SitId && e.UserId == _userId.ToString());
                entity.SitDate = model.SitDate;
                entity.SitLength = model.SitLength;
                entity.Note = model.Note;
                entity.TypeOfSit = model.TypeOfSit;
                entity.SitLink = model.SitLink;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteSit(int sitId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sits.Single(e => e.SitId == sitId && e.UserId == _userId.ToString());
                ctx.Sits.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
