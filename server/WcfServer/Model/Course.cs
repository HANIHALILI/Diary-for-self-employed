using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 public   class Course : BaseEntity
    {
        public Course()
        {

        }
        public Course(int code, TypeCourse typeCourse, string discribtion, string status, double price, int numberOfLessons)
        {
            this.code = code;
            this.codeTypeCourse = typeCourse;
            this.discribtion = discribtion;
            this.status = status;
            this.price = price;
            this.numberOfLessons = numberOfLessons;
        }

        public int code { get; set; }
        public TypeCourse codeTypeCourse { get; set; } 
        public double price { get; set; }
        public string discribtion { get; set; }  
        public int numberOfLessons { get; set; }
        public string status { get; set; }
     


        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "Course";
        }

        public override string ToString()
        {
            return  discribtion + status + price + numberOfLessons;
        }

    }
}
