using OpenQA.Selenium.Chrome;
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
        public TalkService() { }
        public TalkService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTalk(TalkCreate model)
        {
            var entity =
                new Talk()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Topic=model.Topic,
                    TeacherId = model.TeacherId,
                    TalkLength = model.TalkLength,
                    TalkDate = model.TalkDate,
                    IsGuided=model.IsGuided,
                    RetreatId = model.RetreatId,
                    CenterId=model.CenterId,
                    TeacherLinkId=model.TeacherLinkId,
                    TalkLinkId=model.TalkLinkId,
                    //TalkLink=model.TalkLink
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
                                    TeacherName = e.Teachers.FirstName + " " + e.Teachers.LastName,
                                    Topic = e.Topic,
                                    TalkLength = e.TalkLength,
                                    IsGuided=e.IsGuided,
                                    IsStarred=e.IsStarred,
                                    RetreatId = e.RetreatId,
                                    TalkLink= "https://dharmaseed.org/talks/audio_player/" + e.TeacherLinkId + "/" + e.TalkLinkId + ".html"
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
                         TeacherName=entity.Teachers.FullName,
                         TalkLink = "https://dharmaseed.org/talks/audio_player/" + entity.TeacherLinkId + "/" + entity.TalkLinkId + ".html"
                     };
            }
        }
        public TalkListItem GetTalksByTeacherId(int teacherId)
        {
            using (var ctx = new ApplicationDbContext())       
            {
                var entity =
                    ctx
                        .Talks
                        .Single(e => e.TeacherId == teacherId);
                return
                    new TalkListItem
                    {
                        TalkId = entity.TalkId,
                        Name = entity.Name,
                        Topic = entity.Topic,
                        TalkLength = entity.TalkLength,
                        TalkDate = entity.TalkDate,
                        IsGuided = entity.IsGuided,
                        TalkLink = "https://dharmaseed.org/talks/audio_player/" + entity.TeacherLinkId + "/" + entity.TalkLinkId + ".html"
                    };
            }
        }

        //public IEnumerable<TalkDetail>GetAllTalksByTeacherId(int teacherId)
        //{
        //    using (var ctx=new ApplicationDbContext())
        //    {
        //        var talks = new List<TalkDetail>();
        //        var teachers = ctx.Teachers.Where(g => g.TeacherId == teacherId).ToList();
        //        foreach (var teacher in teachers)
        //        {
        //            var teach=ctx.Teachers.FirstOrDefault(u=>u.TeacherId==teacher.TeacherId.ToString())
        //        }
        //    }
        //}
        //public IEnumerable<string> ConvertTalkCollectionToString(ICollection<Talk> talks)
        //{
        //    var query = talks.Select(
        //        e =>
        //            new TalkListItem
        //            {
        //                TalkId = e.TalkId,
        //                Name = e.Name,
        //                TeacherId = e.TeacherId,
        //                Topic = e.Topic,
        //                TalkLength = e.TalkLength,
        //                RetreatId = e.RetreatId
        //            }
        //            );
        //    query.ToArray();
        //    List<string> talkStrings = new List<string>();
        //    foreach (TalkListItem item in query)
        //    {
        //        talkStrings.Add($"{item.Name}, (Teacher Id: {item.TeacherId}),(Topic: {item.Topic}),(Retreat ID: {item.RetreatId})");
        //    }
        //    return talkStrings;
        //}
        public bool UpdateTalk(TalkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Talks
                        .Single(e => e.TalkId == model.TalkId);
                entity.TalkId = model.TalkId;
                entity.Name = model.Name;
                entity.TeacherId = model.TeacherId;
                //entity.Teachers = model.Teacher;
                entity.Topic = model.Topic;
                entity.TalkLength = model.TalkLength;
                entity.TalkDate = model.TalkDate;
                entity.IsGuided = model.IsGuided;
                entity.IsStarred = model.IsStarred;
                //entity.Teachers = model.TeacherName;

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

        //public IEnumerable<TalkListItem> GetTalkScraper()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        using (var driver = new ChromeDriver())
        //        {
        //            driver.Navigate().GoToUrl("https://dharmaseed.org/talks/");
        //            var talkDate = (driver.FindElementByXPath("//div[@class='talklist']/table/tbody/tr/td").Text).ToString();
        //            var talkName = (driver.FindElementByXPath("//div[@class='talklist']/table/tbody/tr/td/a[@class='talkteacher']").Text).ToString();
        //            var talkLength = (driver.FindElementByXPath("//div[@class='talklist']/table/tbody/tr/td/i").Text).ToString();
        //            var talkTeacher = (driver.FindElementByXPath("//div[@class='talklist']/table/tbody/tr/td/i/a[@class='talkteacher']").Text).ToString();
        //            var talkDescription = (driver.FindElementByXPath("//div[@class='talklist']/table/tbody/tr/td").Text).ToString();
        //            var talkCenter = (driver.FindElementByXPath("//div[@class='talklist']/table/tbody/tr/td/a[@class='quietlink']").Text).ToString();

                   
        //        }
        //    }
        //}
    }
}
