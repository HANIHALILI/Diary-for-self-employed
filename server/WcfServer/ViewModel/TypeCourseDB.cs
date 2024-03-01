using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class TypeCourseDB : BaseDB
    {
      public  TypeCourseDB (): base("TypeCourse") { }
        protected override BaseEntity CreateModel()
        {
            TypeCourse typeCourse = new TypeCourse();
            typeCourse.code = (int)reader["code"];
            typeCourse.nameTypeCourse = reader["nameTypeCourse"].ToString();
            return typeCourse;
        }

        public List<TypeCourse> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<TypeCourse>().ToList();
        }

        public TypeCourse GetTypeCourseByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }

     
        //protected string start(int w)
        //{
        //    gethashcode();
        //    return w.tostring();

        //}

    }
}
