using AddressbookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressbookApp.Repositories
{
    public class UserDetailsRepository
    {
        ContactManagerEntities context = new ContactManagerEntities();

        public IEnumerable<Userdetail> GetUserDetails()
        {
            return context.Userdetails.ToList();
        }

        public void InsertUserDetail(Userdetail userDetail)
        {
            context.Userdetails.Add(userDetail);
            context.SaveChanges();
        }

        public Userdetail GetById(int id)
        {
            return context.Userdetails.Where(x => x.PKUserId == id).SingleOrDefault();
        }

        public void UpdateUserDetail(Userdetail userDetail)
        {
            try
            {
                context.Entry(userDetail).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                Userdetail oldEntry = context.Userdetails.Find(userDetail.PKUserId);
                context.Entry(oldEntry).CurrentValues.SetValues(userDetail);
                context.SaveChanges();
            }

        }

        public void DeleteUserDetail(int id)
        {
            context.Userdetails.Remove(GetById(id));
            context.SaveChanges();
        }

        public Userdetail AuthenticateUser(string userName, string password)
        {
            Userdetail objUser = context.Userdetails.Where(user => user.UserName == userName && user.Password == password).SingleOrDefault();
            return objUser;
        }
    }
}
