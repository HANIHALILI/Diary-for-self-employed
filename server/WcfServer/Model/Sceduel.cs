using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public   class Sceduel : BaseEntity
    {
        public Sceduel()
        {

        }
        public Sceduel(int code, DateTime timeInDay, DateTime dateInMonth)
        {
            this.code = code;
          
        }
        public int code { get; set; }
        public DateTime timeInDay { get; set; } //שעה
        public DateTime dateInMonth { get; set; } //תאריך

        public override string[] GetKeyFields()
        {
            return new string[] { "code" };
        }

        public override string GetTableName()
        {
            return "Sceduel";
        }

        public override string ToString()
        {
            return timeInDay.ToString() + dateInMonth.ToString();
        }

   
    }
}
