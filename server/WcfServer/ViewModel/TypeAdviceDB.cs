using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TypeAdviceDB : BaseDB
    {
     public   TypeAdviceDB() : base("TypeAdvice") { }
        protected override BaseEntity CreateModel()
        {
            TypeAdvice typeAdvice = new TypeAdvice();
            typeAdvice.code = (int)reader["code"];
            typeAdvice.nameTypeAdvice = reader["nameTypeAdvice"].ToString();
            return typeAdvice;
        }

        public List<TypeAdvice> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<TypeAdvice>().ToList();
        }

        public TypeAdvice GetTypeAdviceByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }

      
    }
}
