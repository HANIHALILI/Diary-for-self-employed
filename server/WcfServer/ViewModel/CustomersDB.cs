using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CustomersDB:BaseDB
    {
      public  CustomersDB() : base("Customers") { }

        protected override BaseEntity CreateModel()
        {
            Customers customer = new Customers();
            customer.code = (int)reader["code"];
            customer.name = reader["name"].ToString();
            customer.telephone = reader["telephone"].ToString();
            customer.mail = reader["mail"].ToString();
            customer.adress = reader["adress"].ToString();
            customer.city = MyDB.Cities.GetCityByCode((int)reader["city"]);
            customer.notes = reader["notes"].ToString();

            return customer;
        }

        public List<Customers> GetList()
        {

            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<Customers>().ToList();
        }

        public Customers GetCustomerByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.code == code);
        }

      
    }
}
