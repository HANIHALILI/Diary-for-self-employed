using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseDB:BaseDB
    {
        public CourseDB() : base("Course")
        {
        }
        protected override BaseEntity CreateModel()
        {
            Course course = new Course();
            course.code = (int)reader["code"];
            course.codeTypeCourse = MyDB.TPCourse.GetTypeCourseByCode ((int)reader["codeTypeCourse"]);
            course.price = (int)reader["price"];
            course.discribtion = reader["discribtion"].ToString();
            course.status = reader["status"].ToString();
            course.numberOfLessons = (int)reader["numberOfLessons"];

            return course;
        }

        public List<Course> GetList()

        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<Course>().ToList();
        }

        public Course GetCourseByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }

   
    }
}
