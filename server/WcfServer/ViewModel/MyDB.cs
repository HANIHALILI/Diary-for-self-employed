using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;


namespace ViewModel
{
  public  class MyDB
    {
        public static CitiesDB Cities = new CitiesDB();
        public static TypeCourseDB TPCourse = new TypeCourseDB();
        public static TypeAdviceDB TPAdvice = new TypeAdviceDB();
        public static RegistrationForCourseDB RFCourse = new RegistrationForCourseDB();
        public static PersonalMeetingDB PMeeting = new PersonalMeetingDB();
        public static CustomersDB customers = new CustomersDB();
        public static CourseDB course = new CourseDB();
        public static CourseMeetingDB CMeeting = new CourseMeetingDB();
        public static SceduelDB sceduel = new SceduelDB();

    }
}
