using AddressbookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookApp.Repositories
{
    public class StatesRepository
    {
        ContactManagerEntities context = new ContactManagerEntities();

        public IEnumerable<State> GetStates()
        {
            return context.States.ToList();
        }

        public IEnumerable<State> GetStates(int countryId)
        {
            return context.States.Where(s => s.FKCountryId == countryId).ToList();
        }

        public void InsertState(State objState)
        {
            context.States.Add(objState);
            context.SaveChanges();
        }

        public State GetById(int id)
        {
            return context.States.Where(x => x.PKStateId == id).SingleOrDefault();
        }

        public void UpdateState(State state)
        {
            try
            {
                context.Entry(state).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                State oldEntry = context.States.Find(state.PKStateId);
                context.Entry(oldEntry).CurrentValues.SetValues(state);
                context.SaveChanges();               
            }


            
        }

        public void DeleteState(int id)
        {
            context.States.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
