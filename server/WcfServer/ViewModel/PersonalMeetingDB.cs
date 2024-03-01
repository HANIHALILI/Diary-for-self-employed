using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonalMeetingDB : BaseDB
    {
       public PersonalMeetingDB() : base("PersonalMeeting") { }

        protected override BaseEntity CreateModel()
        {
            PersonalMeeting personalMeeting = new PersonalMeeting();
            personalMeeting.code = (int)reader["code"];
            personalMeeting.customer =MyDB.customers.GetCustomerByCode((int)reader["customer"]);
            personalMeeting.dday = MyDB.sceduel.GetSceduelByCode((int)reader["dday"]);
            personalMeeting.typeAdvice = MyDB.TPAdvice.GetTypeAdviceByCode((int)reader["typeAdvice"]);
            personalMeeting.paymentMethod = reader["paymentMethod"].ToString();

            personalMeeting.amountPaid = (int)reader["amountPaid"];
            personalMeeting.howToMeet = reader["howToMeet"].ToString();
            personalMeeting.price = (int)reader["price"];

            personalMeeting.lengthSessionInminutes = (int)reader["lengthSessionInminutes"];
            personalMeeting.isPerformed = (bool)reader["isPerformed"];
            return personalMeeting;
        }

        public List<PersonalMeeting> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<PersonalMeeting>().ToList();
        }

        public PersonalMeeting GetPersonalMeetingByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }



    }
}
