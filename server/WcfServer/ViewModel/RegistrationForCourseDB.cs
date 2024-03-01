using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RegistrationForCourseDB:BaseDB
    {
      public  RegistrationForCourseDB() : base("RegistrationForCourse") { }
        protected override BaseEntity CreateModel()
        {
            RegistrationForCourse registrationForCourse = new RegistrationForCourse();
            registrationForCourse.course = MyDB.course.GetCourseByCode((int)reader["course"]);
            registrationForCourse.customer = MyDB.customers.GetCustomerByCode((int)reader["customer"]);
            registrationForCourse.paymentMethod = reader["paymentMethod"].ToString();
            registrationForCourse.price = (int)reader["price"];

            registrationForCourse.amountPaid = (int)reader["amountPaid"];
            registrationForCourse.notes = reader["notes"].ToString();
            return registrationForCourse;
        }

        public List<RegistrationForCourse> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<RegistrationForCourse>().ToList();
        }

        public RegistrationForCourse GetRegistrationForCourseByCode(int codeCourse1 , int codeCustomer1)
        {
            return GetList().FirstOrDefault(x => x.course.code == codeCourse1 && x.customer.code == codeCustomer1);
        }


    }
}
