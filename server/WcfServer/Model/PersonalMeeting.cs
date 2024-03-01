using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class PersonalMeeting : BaseEntity
    {
        

        public PersonalMeeting()
        {
        }

        public PersonalMeeting(int code, Customers codeCustomer, string paymentMethod, string howToMeet, int amountPaid, TypeAdvice codeTypeAdvice, Sceduel day,  double price, int lengthSessionInminutes, bool isPerformed)
        {
            this.code = code;
            this.customer = codeCustomer;
            this.paymentMethod = paymentMethod;
            this.howToMeet = howToMeet;
            this.amountPaid = amountPaid;
            this.typeAdvice = codeTypeAdvice;
            this.dday = day;

            this.price = price;
            this.lengthSessionInminutes = lengthSessionInminutes;
            this.isPerformed = isPerformed;
        }

        public int code { get; set; }
        public Customers customer { get; set; }
        public TypeAdvice typeAdvice { get; set; }
        public Sceduel dday { get; set; }
       
        public double price { get; set; }
        public double lengthSessionInminutes { get; set; }
        public string paymentMethod { get; set; }
        public double amountPaid { get; set; }
        public string howToMeet { get; set; }
        public bool isPerformed { get; set; }


        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "PersonalMeeting";
        }

        public override string ToString()
        {
            return   dday.ToString()+ price + lengthSessionInminutes + paymentMethod +amountPaid +howToMeet+ isPerformed;
        }







    }
}
