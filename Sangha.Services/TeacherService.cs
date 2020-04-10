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
                    Bio=model.Bio              
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
                                    Bio=e.Bio,
                                    TalkCount=e.Talks.Count
                                    
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
                //var talkService = new TalkService(); from TALKSERVICE METHOD CONVERTALKCOLLECTIONTOSTRING
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id);
                //var query = ctx.Talks.Include("Talks").ToList();
                //var teacherTalks = entity.Talks.ToList();


                var teacherTalks = new List<TalkDetail>();
                foreach (var talk in entity.Talks)
                {
                    var detail = new TalkDetail()
                    //ctx.Talks
                    //    .Where(talk => talk.TeacherId == entity.TeacherId)
                    //    .Select(talk => new TalkDetail
                    {
                        TalkId = talk.TalkId,
                        Name = talk.Name,
                        TeacherId = talk.TeacherId,
                        Topic = talk.Topic,
                        TalkLength = talk.TalkLength,
                        RetreatId = talk.RetreatId,
                        TalkDate = talk.TalkDate,
                        TalkLink = "https://dharmaseed.org/talks/audio_player/" + talk.TeacherLinkId + "/" + talk.TalkLinkId + ".html"
                    };//).ToList();
                    teacherTalks.Add(detail);
                }
                var teacherRetreats =
                    ctx.Retreats.ToList()
                        .Where(r => r.TeacherId == entity.TeacherId)
                        .Select(r => new RetreatListItem
                        {
                            RetreatId = r.RetreatId,
                            RetreatName = r.RetreatName,
                            CenterId= r.CenterId,
                            CenterName=r.Centers.Name,
                            RetreatDate = r.RetreatDate,
                            RetreatLength = r.RetreatLength,
                            AvgRating = r.AvgRating
                        }).ToList();
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Bio=entity.Bio,
                        //Retreats = entity.Retreats,
                        //Centers = entity.Centers,
                        //Talks = teacherTalks.Select(p => new TalkListItem { Name = p.Name, Topic = p.Topic }.ToList)
                        //Talks = talkService.ConvertTalkCollectionToString(entity.Talks)  METHOD FROM TALSERVICE
                        Talks = teacherTalks,
                        Retreats = teacherRetreats
                    };
            }
        }
        //public ICollection<Talk> GetTalks()
        //{
        //    var talks = new List<string>();
        //    foreach (var talk in talks)
        //    {
        //        talks = string.Join(",", talks.ToArray())
        //    }

        //}

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
