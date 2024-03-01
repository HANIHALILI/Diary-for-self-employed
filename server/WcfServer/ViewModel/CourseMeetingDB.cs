using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseMeetingDB : BaseDB
    {

     public CourseMeetingDB() : base("CourseMeeting") { }

        protected override BaseEntity CreateModel()
        {
            CourseMeeting courseMeeting = new CourseMeeting();
            courseMeeting.code = (int)reader["code"];
            courseMeeting.course = MyDB.course.GetCourseByCode((int)reader["course"]);
            courseMeeting.serial = (int)reader["serial"];
            courseMeeting.ddate = MyDB.sceduel.GetSceduelByCode((int)reader[ "ddate"]);
            courseMeeting.isPerformed = (bool)reader["isPerformed"];
            courseMeeting.notes = reader["notes"].ToString();
            courseMeeting.lengthSessionInminutes = (int)reader["lengthSessionInminutes"];
            courseMeeting.contentMeeting = reader["contentMeeting"].ToString();
            return courseMeeting;
        }

        public List<CourseMeeting> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<CourseMeeting>().ToList();
        }

        public CourseMeeting GetCourseMeetingByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }

    
    }
}
