using AddressbookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressbookApp.Repositories;

namespace AddressbookApp.BO
{
    /// <summary>
    /// Class for maintaining business login of State module
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
    /// </remarks>
    public class StatesBO
    {
        #region Initialization
        StatesRepository objStatesRepository = new StatesRepository();
        #endregion

        #region Public Methods
        /// <summary>
        /// This method is used to Retrive all states
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <returns>List of States</returns>
        public IEnumerable<State> GetStates()
        {
            return objStatesRepository.GetStates();
        }
        /// <summary>
        /// This method is used to retrieve states based on country Id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="countryId">contains Country Id</param>
        /// <returns>List of States</returns>
        public IEnumerable<State> GetStates(int countryId)
        {
            return objStatesRepository.GetStates(countryId);
        }
        /// <summary>
        /// This method is used to insert new State
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="objState">contains details of new State</param>
        public void InsertState(State objState)
        {
            objStatesRepository.InsertState(objState);
        }
        /// <summary>
        /// This method is used to retrieve State based on State Id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="id">contains State Id</param>
        /// <returns>State</returns>
        public State GetById(int id)
        {
            return objStatesRepository.GetById(id);
        }
        /// <summary>
        /// This method is used to update existed state
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="state">contains details of an existed state</param>
        public void UpdateState(State state)
        {
            objStatesRepository.UpdateState(state);
        }
        /// <summary>
        /// This method is used to delte state based on State Id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="id">Contains State Id</param>
        public void DeleteState(int id)
        {
            objStatesRepository.DeleteState(id);
        }
        #endregion
    }
}
