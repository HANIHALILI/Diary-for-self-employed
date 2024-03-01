using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class CourseMeeting : BaseEntity
    {
        public CourseMeeting()
        {

        }
        public CourseMeeting(int code, Course course, int serial, Sceduel date, bool isPerformed, string contentMeeting) 
        {
            this.code = code;
            this.course = course;
            this.serial = serial;
          
            this.ddate = date;
            this.isPerformed = isPerformed;
            this.contentMeeting = this.contentMeeting;

        }
        

        public int code { get; set; }
        public Course course { get; set; }
        public int serial { get; set; } //מספר סידורי של השיעור
   
        public Sceduel ddate { get; set; } //תאריך
        public bool isPerformed { get; set; }
        public string contentMeeting { get; set; } //תוכן המפגש
        public int lengthSessionInminutes { get; set; } //זמן בדקות
        public string notes { get; set; }


        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "CourseMeeting";
        }

        public override string ToString()
        {
            return  notes + lengthSessionInminutes + contentMeeting + isPerformed + ddate + serial ;
        }

    }


}

