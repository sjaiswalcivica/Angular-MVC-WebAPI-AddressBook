using AddressbookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressbookApp.Repositories
{
   public class AddressBookRepository
    {
        ContactManagerEntities context = new ContactManagerEntities();

        public IEnumerable<Addressbook> GetAddresses(int countryId = 0, int stateId = 0, bool? isActive = null, int userId=0)
        {
            IQueryable<Addressbook> qry = context.Addressbooks;
            if (userId!=0)
                qry = qry.Where(address => address.FKUserId == userId);
            if (stateId != 0)
            {
                qry = qry.Where(address => address.FKStateId == stateId);
            }
            else if (countryId != 0)
            {
                var stateIds = context.States.Where(state => state.FKCountryId == countryId).Select(state => state.PKStateId);
                qry = qry.Where(address => stateIds.Contains(address.FKStateId));
            }
            if (isActive.HasValue)
            {
                qry = qry.Where(address => address.IsActive == isActive.Value);
            }

            //var q = (from a in qry
            //         join s in context.States on a.FKStateId equals s.PKStateId
            //         join c in context.Countries on s.FKCountryId equals c.PKCountryId
            //         select new
            //         {
            //             PKAddressId = a.PKAddressId,
            //             FirstName = a.FirstName,
            //             LastName = a.LastName,
            //             EmailId = a.EmailId,
            //             PhoneNo = a.PhoneNo,
            //             Street = a.Street,
            //             City = a.City,
            //             FKStateId = s.PKStateId,
            //             CountryName = c.CountryName,
            //             StateName = s.StateName,
            //             ZipCode = a.ZipCode,
            //             IsActive = (bool)a.IsActive
            //         }).AsEnumerable().Select(x => new Addressbook
            //         {
            //             PKAddressId = x.PKAddressId,
            //             FirstName = x.FirstName,
            //             LastName = x.LastName,
            //             EmailId = x.EmailId,
            //             PhoneNo = x.PhoneNo,
            //             Street = x.Street,
            //             City = x.City,
            //             FKStateId = x.FKStateId,
            //             CountryName = x.CountryName,
            //             StateName = x.StateName,
            //             ZipCode = x.ZipCode,
            //             IsActive = (bool)x.IsActive

            //         });
            return qry.ToList();
        }

        public void InsertAddressbook(Addressbook address)
        {
            context.Addressbooks.Add(address);
            context.SaveChanges();
        }

        public Addressbook GetById(int id)
        {
            return context.Addressbooks.Where(x => x.PKAddressId == id).SingleOrDefault();
        }

        public void UpdateAddressbook(Addressbook address)
        {
            try
            {
                context.Entry(address).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                Addressbook oldEntry = context.Addressbooks.Find(address.PKAddressId);
                context.Entry(oldEntry).CurrentValues.SetValues(address);
                context.SaveChanges();
            }
        }

        public void DeleteAddressbook(int id)
        {
            context.Addressbooks.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
