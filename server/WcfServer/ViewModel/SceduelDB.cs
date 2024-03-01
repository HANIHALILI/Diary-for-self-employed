using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
     public class SceduelDB : BaseDB
      {
        public SceduelDB() : base("Sceduel") { }
        protected override BaseEntity CreateModel()
        {
            Sceduel sceduel = new Sceduel();
            sceduel.code = (int)reader["code"];
            sceduel.dateInMonth = (DateTime)reader["dateInMonth"];
            sceduel.timeInDay = (DateTime)reader["timeInDay"];
            return sceduel;
        }

        public List<Sceduel> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<Sceduel>().ToList();
        }

        public Sceduel GetSceduelByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }


    }
}
