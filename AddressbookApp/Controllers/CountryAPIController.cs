using AddressbookApp.BO;
using AddressbookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressbookApp.Controllers
{
    /// <summary>
    /// Api for performing CRUD Operations.
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
    /// </remarks>
    public class CountryAPIController : ApiController
    {
        #region Initialization
        CountryBO objCountryBO = new CountryBO();
        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// Used for configuration Settings in GlobalConfiguration
        /// </summary>
        public CountryAPIController()
        {
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            //json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This method is used for handling model state errors.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Viswaraj (2-Nov-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <returns>List of model state error messages</returns>
        private IEnumerable<string> GetErrorMessages()
        {
            //Returns an array of error messages.
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This method is used to retrieve all Countries.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="request">contains current request message</param>
        /// <returns> list of all Countries if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            try
            {
                IEnumerable<Country> countries = objCountryBO.GetCountries();                
                if (countries == null)
                {
                    return request.CreateResponse(HttpStatusCode.NoContent);
                }
                return request.CreateResponse(HttpStatusCode.OK, countries);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }

        /// <summary>
        /// This method is used to retrieve country based on countryId.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="id">contains Country Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>country if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                Country country = objCountryBO.GetById(id);
                if (country == null)
                    return request.CreateResponse(HttpStatusCode.NoContent);
                return request.CreateResponse(HttpStatusCode.OK, country);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }

        /// <summary>
        /// This method is used to add new country to the database
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in adding new country to database</exception>
        /// <param name="objCountry">contians data of new Country which is to be added</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all countries if HttpStatusCode is OK</returns>
        public HttpResponseMessage Post([FromBody]Country objCountry, HttpRequestMessage request)
        {
           
            try
            {
                if (!ModelState.IsValid)                
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objCountryBO.InsertCountry(objCountry);
                return request.CreateResponse(HttpStatusCode.OK, objCountryBO.GetCountries());                
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }           
        }

        /// <summary>
        /// This method is used to update the existing country in the database.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in updating existed country in database</exception>
        /// <param name="objCountry">contains the existing country in database</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all countries if HttpStatusCode is OK</returns>
        public HttpResponseMessage Put(Country objCountry, HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objCountryBO.UpdateCountry(objCountry);
                return request.CreateResponse(HttpStatusCode.OK, objCountryBO.GetCountries());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }
        /// <summary>
        /// This method is used to delete the country from the database.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in deleting country from database</exception>
        /// <param name="id">contains the country Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all countries if HttpStatusCode is OK</returns>
        public HttpResponseMessage Delete(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                objCountryBO.DeleteCountry(id);
                return request.CreateResponse(HttpStatusCode.OK, objCountryBO.GetCountries());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }

        #endregion
    }
}
