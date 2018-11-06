using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressbookApp.Models;

namespace AddressbookApp.Repositories
{
  public class CountryRepository
    {
        ContactManagerEntities context = new ContactManagerEntities();

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public void InsertCountry(Country objCountry)
        {
            context.Countries.Add(objCountry);
            context.SaveChanges();
        }

        public Country GetById(int id)
        {
            return context.Countries.Where(x => x.PKCountryId == id).SingleOrDefault();
        }

        public void UpdateCountry(Country country)
        {
            context.Entry(country).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            context.Countries.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
