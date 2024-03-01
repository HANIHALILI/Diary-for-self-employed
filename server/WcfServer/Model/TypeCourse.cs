
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class TypeCourse : BaseEntity
    {
        public TypeCourse()
        {

        }
        public TypeCourse(int code, string nameTypeCourse)
        {
            this.code = code;
            this.nameTypeCourse = nameTypeCourse;
        }
        public int code { get; set; }
        public string nameTypeCourse { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "TypeCourse";
        }

        public override string ToString()
        {
            return nameTypeCourse;
        }
    }
}
