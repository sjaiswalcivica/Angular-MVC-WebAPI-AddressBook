using AddressbookApp.BO;
using AddressbookApp.Utility;
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
    /// Api for performing AddressBook CRUD Operations.
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
    /// </remarks>
    public class AddressBookAPIController : ApiController
    {
        #region Initialization
        AddressBO objAddressBookBO = new AddressBO();
        #endregion

        #region Private Methods

        /// <summary>
        /// This method is used for handling model AddressBook errors.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <returns>List of model State error messages</returns>
        private IEnumerable<string> GetErrorMessages()
        {
            //Returns an array of error messages.
            return ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
        }
        #endregion

        #region Constructors
        public AddressBookAPIController()
        {
            
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method is used to retrieve all Addresses.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="request">contains current request message</param>
        /// <returns> list of all Addresses if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            try
            {
                IEnumerable<Addressbook> addresses = objAddressBookBO.GetAddresses();
                if (addresses == null)
                {
                    return request.CreateResponse(HttpStatusCode.NoContent);
                }
                return request.CreateResponse(HttpStatusCode.OK, addresses);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }
        /// <summary>
        /// This method is used to retrieve all Addresses based on User Id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <param name="userId">containse Current User Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>List of Addressess</returns>
        public HttpResponseMessage Get(string userId, HttpRequestMessage request)
        {
            try
            {
                IEnumerable<Addressbook> addresses = objAddressBookBO.GetAddresses(0,0,null,Convert.ToInt32(userId));
                if (addresses == null)
                {
                    return request.CreateResponse(HttpStatusCode.NoContent);
                }
                return request.CreateResponse(HttpStatusCode.OK, addresses);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }
        /// <summary>
        /// This method is used to retrieve Address based on Address Id.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="id">contains Address Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>AddressBook if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                Addressbook address = objAddressBookBO.GetById(id);
                if (address == null)
                    return request.CreateResponse(HttpStatusCode.NoContent);
                return request.CreateResponse(HttpStatusCode.OK, address);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }          
        }

        //public IEnumerable<Addressbook> Get(int userId, string userName)
        //{
        //    return objAddressBookBO.GetAddresses();
        //}
        //public IEnumerable<Addressbook> Get(int countryId, int stateId, bool status)
        //{
        //    if (Helper.CurrentUserRole != "Admin")
        //    return objAddressBookBO.GetAddresses(0, stateId, status,Helper.CurrentUserID);
        //    else
        //        return objAddressBookBO.GetAddresses(0, stateId, status);            
        //}


        /// <summary>
        /// This method is used to add new Address to the database
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in adding new Address to database</exception>
        /// <param name="address">contians data of new AddressBook which is to be added</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all AddressBooks if HttpStatusCode is OK</returns>
        public HttpResponseMessage Post([FromBody]Addressbook address, HttpRequestMessage request)
        {
            address.FKUserId = Helper.CurrentUserID;
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objAddressBookBO.InsertAddressbook(address);
                return request.CreateResponse(HttpStatusCode.OK, objAddressBookBO.GetAddresses());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }            
        }
        /// <summary>
        /// This method is used to update  existing AddressBook in the database
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in updating AddressBook in database</exception>
        /// <param name="address">contians data of existed Addressbook which is to be updated</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all AddressBooks if HttpStatusCode is OK</returns>
        public HttpResponseMessage Put(Addressbook address, HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objAddressBookBO.UpdateAddressbook(address);
                return request.CreateResponse(HttpStatusCode.OK, objAddressBookBO.GetAddresses());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }

        /// <summary>
        /// This method is used to delete the AddressBook from the database.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in deleting AddressBook from database</exception>
        /// <param name="id">contains the Address Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all AddressBooks if HttpStatusCode is OK</returns>
        public HttpResponseMessage Delete(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                objAddressBookBO.DeleteAddressbook(id);
                return request.CreateResponse(HttpStatusCode.OK, objAddressBookBO.GetAddresses());
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
