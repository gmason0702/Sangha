//using Sangha.Data;
//using Sangha.Models.TeacherModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sangha.Services
//{
//    public class TeacherService
//    {
//        private readonly Guid _userId;

//        public TeacherService(Guid userId)
//        {
//            _userId = userId;
//        }

//        public bool CreateTeacher(TeacherCreate model)
//        {
//            var entity =
//                new Teacher()
//                {
//                    //OwnerId = _userId,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName
//                };

//            using (var ctx = new ApplicationDbContext())
//            {
//                ctx.Teachers.Add(entity);
//                return ctx.SaveChanges() == 1;
//            }
//        }
//        public IEnumerable<TeacherListItem> GetTeachers()
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var query =
//                    ctx
//                        .Teachers
//                        //.Where(e => e.OwnerId == _userId)
//                        .Select(
//                            e =>
//                                new TeacherListItem
//                                {
//                                    FirstName = e.FirstName,
//                                    LastName = e.LastName,
//                                    Talks = e.Talks,
//                                    Retreats = e.Retreats,
//                                    Centers = e.Centers
//                                }
//                        );

//                return query.ToArray();
//            }
//        }
//        public TeacherDetail GetTeacherById(int id)
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var entity =
//                    ctx
//                        .Teachers
//                        .Single(e => e.TeacherId == id);
//                return
//                    new TeacherDetail
//                    {
//                        FirstName = entity.FirstName,
//                        LastName = entity.LastName,
//                        Talks = entity.Talks,
//                        Retreats = entity.Retreats,
//                        Centers = entity.Centers

//                    };
//            }
//        }
//    }
//}
