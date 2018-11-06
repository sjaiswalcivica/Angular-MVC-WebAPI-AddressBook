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
    /// This class is used for maintaining Business logic of AddressBook
    /// </summary>
    /// <remarks>
    /// Date Created: 24th Oct 2016
    /// Edited By : Phani ( 4-11-2016)
   /// </remarks>
   public class AddressBO
    {
        #region Initialization
        AddressBookRepository objAddressBookRepository = new AddressBookRepository();
        #endregion

        #region Public Methods
        /// <summary>
        /// This method is used for retrieving all addresses
        /// </summary>
        /// <remarks>
        /// Date Created: 24th Oct 2016
        /// Edited By : Phani ( 4-11-2016)
        /// </remarks>
        /// <param name="countryId">contains Country Id</param>
        /// <param name="stateId">contains State Id</param>
        /// <param name="isActive">Contains Active status of Address</param>
        /// <param name="userId">contains User Id</param>
        /// <returns>List of AddressBooks</returns>
        public IEnumerable<Addressbook> GetAddresses(int countryId = 0, int stateId = 0, bool? isActive = null,int userId=0)
        {
            return objAddressBookRepository.GetAddresses(countryId, stateId, isActive, userId);
        }
        /// <summary>
        /// This method is used for Inserting new address
        /// </summary>
        /// <remarks>
        /// Date Created: 24th Oct 2016
        /// Edited By : Phani ( 4-11-2016)
        /// </remarks>
        /// <param name="address">contains details of new address</param>
        public void InsertAddressbook(Addressbook address)
        {
            objAddressBookRepository.InsertAddressbook(address);
        }
        /// <summary>
        /// This method is used for retrieving Address by Address Id
        /// </summary>
        /// <remarks>
        /// Date Created: 24th Oct 2016
        /// Edited By : Phani ( 4-11-2016)
        /// </remarks>
        /// <param name="id">contains Address Id</param>
        /// <returns>AddressBook</returns>
        public Addressbook GetById(int id)
        {
            return objAddressBookRepository.GetById(id);
        }
        /// <summary>
        /// This method is used for updating AddressBook 
        /// </summary>
        /// <remarks>
        /// Date Created: 24th Oct 2016
        /// Edited By : Phani ( 4-11-2016)
        /// </remarks>
        /// <param name="address">Contains details of existed address</param>
        public void UpdateAddressbook(Addressbook address)
        {
            objAddressBookRepository.UpdateAddressbook(address);
        }
        /// <summary>
        /// This method is used for deleting Addressbook By Address Id
        /// </summary>
        /// <remarks>
        /// Date Created: 24th Oct 2016
        /// Edited By : Phani ( 4-11-2016)
        /// </remarks>
        /// <param name="id">contains AddressBook Id</param>
        public void DeleteAddressbook(int id)
        {
            objAddressBookRepository.DeleteAddressbook(id);
        }
        #endregion
    }
}
