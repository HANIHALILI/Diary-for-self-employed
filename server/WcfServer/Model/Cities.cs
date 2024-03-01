using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cities: BaseEntity
    {
        public Cities()
        {

        }
       public Cities(int code, string nameCity) 
        {
            this.code = code;
            this.nameCity = nameCity;
        }
        public int code { get; set; }
        public string nameCity { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "Cities";
        }

        public override string ToString()
        {
            return nameCity;
        }


    }
}
