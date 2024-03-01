using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace WcfServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        //Add fanctions.
        public int AddCustomers(Customers c)
        {
            MyDB.customers.Add(c);
             return MyDB.customers.SaveChanges();

        }
        public int AddSceduel(Sceduel c)
        {
            MyDB.sceduel.Add(c);
            return MyDB.sceduel.SaveChanges();


        }

        public int AddCity(Cities c)
        {
            MyDB.Cities.Add(c);
            return MyDB.Cities.SaveChanges();
        }
        public int AddPersonalMeeting(PersonalMeeting p)
        {
            MyDB.PMeeting.Add(p);
            return MyDB.PMeeting.SaveChanges();

        }

        public int AddCourse(Course c)
        {
            MyDB.course.Add(c);
            return MyDB.course.SaveChanges();

        }

        public int AddPersonToCourse(RegistrationForCourse rf)
        {
            MyDB.RFCourse.Add(rf);
            return MyDB.RFCourse.SaveChanges();
        }

        public int AddCourseMeeting(CourseMeeting cm)
        {
            MyDB.CMeeting.Add(cm);
            return MyDB.CMeeting.SaveChanges();
        }

        public int AddTypeCourse(TypeCourse tc)
        {
            MyDB.TPCourse.Add(tc);
            return MyDB.TPCourse.SaveChanges();
        }

        public int AddTypeAdvice(TypeAdvice ta)
        {
            MyDB.TPAdvice.Add(ta);
            return MyDB.TPAdvice.SaveChanges();
        }
        //Update fanctions.

        public int UpdateCustomers(Customers c)
        {
            MyDB.customers.Update(c);
            return MyDB.customers.SaveChanges();

        }
        public int UpdateSceduel(Sceduel c)
        {
            MyDB.sceduel.Update(c);
            return MyDB.sceduel.SaveChanges();

        }
        public int UpdatePersonalMeeting(PersonalMeeting p)
        {
            MyDB.PMeeting.Update(p);
            return MyDB.PMeeting.SaveChanges();

        }

        public int UpdateCourse(Course c)
        {
            MyDB.course.Update(c);
            return MyDB.course.SaveChanges();

        }

        public int UpdateCities(Cities c)
        {
            MyDB.Cities.Update(c);
            return MyDB.Cities.SaveChanges();

        }

        public int UpdateCourseMeeting(CourseMeeting cm)
        {
            MyDB.CMeeting.Update(cm);
            return MyDB.CMeeting.SaveChanges();

        }

        public int UpdateRegistrationToCourse(RegistrationForCourse rc)
        {
            MyDB.RFCourse.Update(rc);
            return MyDB.RFCourse.SaveChanges();

        }

        public int UpdateTypeCurse(TypeCourse tc)
        {
            MyDB.TPCourse.Update(tc);
            return MyDB.TPCourse.SaveChanges();

        }

        public int UpdateTypeAdvice(TypeAdvice ta)
        {
            MyDB.TPAdvice.Update(ta);
            return MyDB.TPAdvice.SaveChanges();

        }

        //Delete fanctions.
        public int DeleteCustomers(Customers c)
        {
            MyDB.customers.Deleted(c);
            return MyDB.customers.SaveChanges();

        }
        public int DeleteSceduel(Sceduel c)
        {

            MyDB.sceduel.Deleted(c);
            return MyDB.sceduel.SaveChanges();
        }
        public int DeletePersonalMeeting(PersonalMeeting p)
        {
            MyDB.PMeeting.Deleted(p);
            return MyDB.PMeeting.SaveChanges();

        }

        public int DeleteCourse(Course c)
        {
            MyDB.course.Deleted(c);
            return MyDB.course.SaveChanges();

        }

        public int DeleteCity(Cities c)
        {
            MyDB.Cities.Deleted(c);
            return MyDB.Cities.SaveChanges();

        }

        public int DeleteRegistrationToCourse(RegistrationForCourse rfc)
        {
            MyDB.RFCourse.Deleted(rfc);
            return MyDB.RFCourse.SaveChanges();

        }

        public int DeleteTypeCourse(TypeCourse tc)

        {
            MyDB.TPCourse.Deleted(tc);
            return   MyDB.TPCourse.SaveChanges();

        }

        public int DeleteTypeAdvice(TypeAdvice ta)
        {
            MyDB.TPAdvice.Deleted(ta);
            return MyDB.TPAdvice.SaveChanges();

        }

        public int DeleteCourseMeeting(CourseMeeting cm)
        {
            MyDB.CMeeting.Deleted(cm);
            return MyDB.CMeeting.SaveChanges();

        }
        //GetCode fanctions.

        public int GetCodeToCustomers()
        {
            if (MyDB.customers.GetList().Count == 0) return 1;

            return MyDB.customers.GetList().Max(x => x.code) + 1;
        }
      public int GetCodeToSceduel()
        {
            if (MyDB.sceduel.GetList().Count == 0) return 1;

            return MyDB.sceduel.GetList().Max(x => x.code) + 1;
        }
        public int GetCodeToCourseMeeting()
        {
            if (MyDB.CMeeting.GetList().Count == 0) return 1;

            return MyDB.CMeeting.GetList().Max(x => x.code) + 1;
        }
        public  int GetCodeToPersonalMeeting()
        {
            if (MyDB.PMeeting.GetList().Count == 0) return 1;
            return MyDB.PMeeting.GetList().Max(x => x.code) + 1;
        }
      
      public  int GetCodeToCourse()
        {
            if (MyDB.course.GetList().Count == 0) return 1;
            return MyDB.course.GetList().Max(x => x.code) + 1;
        }
      
      
      public  int GetCodeToCity()
        {
            if (MyDB.Cities.GetList().Count == 0) return 1;
            return MyDB.Cities.GetList().Max(x => x.code) + 1;
        }
      
      public  int GetCodeToTypeCourse()
        {
            if (MyDB.TPCourse.GetList().Count == 0) return 1;
            return MyDB.TPCourse.GetList().Max(x => x.code) + 1;
        }
      
      public  int GetCodeToTypeAdvice()
        {
            if (MyDB.TPAdvice.GetList().Count == 0) return 1;
            return MyDB.TPAdvice.GetList().Max(x => x.code) + 1;
        }
      
        
        //Get fanctions.
        public List<PersonalMeeting> GetPersonalMeetingList()
        {
            return  MyDB.PMeeting.GetList();
        }

        public List<RegistrationForCourse> GetRegistrationToCourseList()
        {
            return MyDB.RFCourse.GetList();
        }

        public List<Course> GetCourseList()
        {
            return MyDB.course.GetList();
        }

        public List<CourseMeeting> GetCourseMeetingList()
        {
            return MyDB.CMeeting.GetList();
        }
        public List<Customers> GetCustomersList()
        {
            return MyDB.customers.GetList();
        }

        public List<Cities> GetCitiesList()
        {
            return MyDB.Cities.GetList();
        }
        public List<Sceduel> GetSceduelList()
        {
            return MyDB.sceduel.GetList();
        }
        public List<TypeAdvice> GetTypeAdviceList()
        {
            return MyDB.TPAdvice.GetList();
        }

        public List<TypeCourse> GetTypeCourseList()
        {
            return MyDB.TPCourse.GetList();
        }
        public int AddLstCourseMeeting(int x, Course course)
        { 
            int y;
            if (MyDB.CMeeting.GetList().Count == 0)
                y = 1;
            else
                y = MyDB.CMeeting.GetList().Max(h => h.code) + 1;

            CourseMeeting c = new CourseMeeting();
            for (int i =0; i < x; i++)
            {
                c.code = y;
                c.course = course;
                c.serial = i+1; ;
                c.notes = " ";
                c.contentMeeting = " ";
                MyDB.CMeeting.Add(c);
                y = MyDB.CMeeting.GetList().Max(h => h.code) + 1;
                MyDB.CMeeting.SaveChanges();
            }
            //  return MyDB.CMeeting.SaveChanges();
            return 1;
        }


    }
}
