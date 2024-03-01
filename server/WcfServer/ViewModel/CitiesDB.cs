using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class  CitiesDB:BaseDB
    {
        public CitiesDB() : base("cities")
        {
        }
        protected override BaseEntity CreateModel()
        {
            Cities city = new Cities();
            city.code = (int)reader["code"];
            city.nameCity = reader["nameCity"].ToString();
            return city;
        }

        public List<Cities> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<Cities>().ToList();
        }

        public Cities GetCityByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }

    
    }
} 
