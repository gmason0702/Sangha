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
                    SitDate = model.SitDate,
                    SitLength = model.SitLength,
                    Note = model.Note,
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
                            SitDate = e.SitDate,
                            SitLength = e.SitLength,
                            Note=e.Note,
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
                    SitLink = entity.SitLink
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
