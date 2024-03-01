using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Customers : BaseEntity
    {
        public Customers()
        {
        }

        public Customers(int code, string name, string telephone, string adress, string mail, Cities codeCity,string notes)
        {
            this.code = code;
            this.name = name;
            this.telephone = telephone;
            this.adress = adress;
            this.mail = mail;
            this.city = codeCity;
            this.notes = notes;
        }

        public int code { get; set; }
        public string name { get; set; }
      
        public string telephone { get; set; }
        public string mail { get; set; }
        public string adress { get; set; }
        public Cities city { get; set; }
        public string notes { get; set; }




        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "Customers";
        }

        public override string ToString()
        {
            return    adress +  mail + telephone + name + notes;
        }
       
    }


}
