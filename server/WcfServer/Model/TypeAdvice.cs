using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class TypeAdvice : BaseEntity
    {
        public TypeAdvice()
        {

        }
        public TypeAdvice(int code, string nameTypeAdvice)
        {
           this.code = code;
           this.nameTypeAdvice = nameTypeAdvice;
        }
        public int code { get; set; }
        public string nameTypeAdvice { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "TypeAdvice";
        }

        public override string ToString()
        {
            return  nameTypeAdvice;
        }

    }
}
