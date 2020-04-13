using Sangha.Data;
using Sangha.Models.RetreatModels;
using Sangha.Models.TalkModels;
using Sangha.Models.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class TeacherService
    {
        private readonly Guid _userId;

        public TeacherService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeacher(TeacherCreate model)
        {
            var entity =
                new Teacher()
                {
                    //OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Bio = model.Bio
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teachers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeacherListItem> GetTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teachers
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeacherListItem
                                {
                                    TeacherId = e.TeacherId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Talks = e.Talks,
                                    Bio = e.Bio,
                                    TalkCount = e.Talks.Count,

                                    //Retreats = e.Retreats,
                                    //Centers = e.Centers
                                }
                        );
                return query.ToArray();
            }
        }
        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id);

                var teacherTalks = new List<TalkDetail>();
                foreach (var talk in entity.Talks)
                {
                    var detail = new TalkDetail()
                    {
                        TalkId = talk.TalkId,
                        Name = talk.Name,
                        TeacherId = talk.TeacherId,
                        Topic = talk.Topic,
                        TalkLength = talk.TalkLength,
                        RetreatId = talk.RetreatId,
                        TalkDate = talk.TalkDate,
                        TalkLink = "https://dharmaseed.org/talks/audio_player/" + talk.TeacherLinkId + "/" + talk.TalkLinkId + ".html"
                    };
                    teacherTalks.Add(detail);
                }

                var retreats = entity.Talks.Select(t => t.Retreats).ToList();
                var teacherRetreats = new List<RetreatListItem>();
                foreach (var r in retreats)
                {
                    var list = new RetreatListItem()
                    {
                        RetreatId = r.RetreatId,
                        RetreatName = r.RetreatName,
                        CenterId = r.CenterId,
                        CenterName = r.Centers.Name,
                        RetreatDate = r.RetreatDate,
                        RetreatLength = r.RetreatLength,
                        AvgRating = r.AvgRating
                    };
                    teacherRetreats.Add(list);
                }
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Bio = entity.Bio,
                        Retreats = teacherRetreats,
                        Talks = teacherTalks
                    };
            }
        }

        public bool UpdateTeacher(TeacherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == model.TeacherId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Bio = model.Bio;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeacher(int teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == teacherId);
                ctx.Teachers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
