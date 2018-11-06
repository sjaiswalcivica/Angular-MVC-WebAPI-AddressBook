using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressbookApp.Repositories;
using AddressbookApp.Models;

namespace AddressbookApp.BO
{
    /// <summary>
    /// Class for maintaining business login of country module
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
    /// </remarks>
    public class CountryBO
    {
        #region Initialization
        CountryRepository objCountryRepository = new CountryRepository();
        #endregion

        #region Public Methods

        /// <summary>
        /// This method is used to retrieve all Countries
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <returns>List of Countries</returns>
        public IEnumerable<Country> GetCountries()
        {
            return objCountryRepository.GetCountries();
        }
        /// <summary>
        /// This method is used for inserting new Country
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="objCountry">contains data of new country to be added</param>
        public void InsertCountry(Country objCountry)
        {
            objCountryRepository.InsertCountry(objCountry);
        }
        /// <summary>
        /// This method is used for retrieving country based on country Id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks> 
        /// <param name="id">contains Country Id</param>
        /// <returns>country</returns>
        public Country GetById(int id)
        {
            return objCountryRepository.GetById(id);
        }
        /// <summary>
        /// This method is used for Updating country
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="country">contains data of existed country</param>
        public void UpdateCountry(Country country)
        {
            objCountryRepository.UpdateCountry(country);
        }
        /// <summary>
        /// This method is used for deleting Country based on country id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="id">contains Country Id</param>
        public void DeleteCountry(int id)
        {
            objCountryRepository.DeleteCountry(id);
        }
        #endregion
    }
}
