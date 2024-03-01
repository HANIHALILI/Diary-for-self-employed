using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 public   class RegistrationForCourse : BaseEntity
    {

        public RegistrationForCourse()
        {

        }
        public RegistrationForCourse(Course course, Customers customer, int amountPaid, string notes, string paymentMethod) 
        {
            this.course = course;
            this.customer = customer;
            this.amountPaid = amountPaid;
            this.paymentMethod = paymentMethod;
            this.notes = notes;
        }
        public Course course { get; set; }

        public Customers customer { get; set; }

        public int amountPaid { get; set; }
        public string paymentMethod { get; set; }
        public string notes { get; set; }
        public int price { get; set; }
        public override string[] GetKeyFields()
        {
            return new string[] {"course","customer"};

        }

        public override string GetTableName()
        {
            return "RegistrationForCourse";
        }

        public override string ToString()
        {
            return   amountPaid.ToString() + paymentMethod + notes;
        }




    }
}
