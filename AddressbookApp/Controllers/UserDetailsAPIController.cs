using AddressbookApp.BO;
using AddressbookApp.Models;
using AddressbookApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressbookApp.Controllers
{
    /// <summary>
    /// Api for performing UserDetails CRUD Operations.
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
    /// </remarks>
    [RoutePrefix("api/UserDetailsAPI")]
    public class UserDetailsAPIController : ApiController
    {
        #region Initialization
        UserDetailsBO objUserDetailsBO = new UserDetailsBO();
        #endregion

        #region Constructors
        public UserDetailsAPIController()
        {
            
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// This method is used for handling model UserDetail errors.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
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
        /// This method is used to retrieve all UserDetails.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="request">contains current request message</param>
        /// <returns> list of all UserDetails if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            try
            {
                IEnumerable<Userdetail> users = objUserDetailsBO.GetUserDetails();
                if (users == null)
                {
                    return request.CreateResponse(HttpStatusCode.NoContent);
                }
                return request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }           
        }
        /// <summary>
        /// This method is used to retrieve userDetail based on user Id.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="id">contains user Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>UserDetails if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(int id,HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                Userdetail user= objUserDetailsBO.GetById(id);
                if (user == null)
                    return request.CreateResponse(HttpStatusCode.NoContent);
                return request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }
        [Route("GetLoginUser")]
        public HttpResponseMessage GetLoginUser(HttpRequestMessage request)
        {
            try
            {
                Userdetail user = objUserDetailsBO.GetById(Helper.CurrentUserID);
                if (user == null)
                    return request.CreateResponse(HttpStatusCode.NoContent);
                return request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }
        /// <summary>
        /// This method is used to add new User to the database
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in adding new User to database</exception>
        /// <param name="userDetail">contians data of new UserDetail which is to be added</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all UserDetails if HttpStatusCode is OK</returns>
        public HttpResponseMessage Post([FromBody]Userdetail userDetail, HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objUserDetailsBO.InsertUserDetail(userDetail);
                return request.CreateResponse(HttpStatusCode.OK, objUserDetailsBO.GetUserDetails());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }            
        }

        /// <summary>
        /// This method is used to update the existing user in the database.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in updating existed user in database</exception>
        /// <param name="userDetail">contains the existing UserDetail in database</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all UserDetails if HttpStatusCode is OK</returns>
        public HttpResponseMessage Put(Userdetail userDetail, HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objUserDetailsBO.UpdateUserDetail(userDetail);
                return request.CreateResponse(HttpStatusCode.OK, objUserDetailsBO.GetUserDetails());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
            
        }

        /// <summary>
        /// This method is used to delete the User from the database.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in deleting user from database</exception>
        /// <param name="id">contains the User Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all UserDetials if HttpStatusCode is OK</returns>
        public HttpResponseMessage Delete(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                objUserDetailsBO.DeleteUserDetail(id);
                return request.CreateResponse(HttpStatusCode.OK, objUserDetailsBO.GetUserDetails());
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
