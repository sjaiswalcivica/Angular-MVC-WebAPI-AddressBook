using AddressbookApp.BO;
using AddressbookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AAddressbookApp.Controllers
{
    /// <summary>
    /// Api for performing State CRUD Operations.
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
    /// </remarks>
    public class StatesAPIController : ApiController
    {
        #region Initialization
        StatesBO objStateBO = new StatesBO();
        #endregion

        #region Private Methods

        /// <summary>
        /// This metho is used for handling model state errors.
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

        #region Constructors

        public StatesAPIController()
        {
            
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method is used to retrieve all States.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="request">contains current request message</param>
        /// <returns> list of all States if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            try
            {
                IEnumerable<State> states = objStateBO.GetStates();
                if (states == null)
                {
                    return request.CreateResponse(HttpStatusCode.NoContent);
                }
                return request.CreateResponse(HttpStatusCode.OK, states);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }          
        }
        /// <summary>
        /// This method is used to retrieve State based on state Id.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in retrieving data from database</exception>
        /// <param name="id">contains State Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>State if HttpStatusCode is OK</returns>
        public HttpResponseMessage Get(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                State state = objStateBO.GetById(id);
                if (state == null)
                    return request.CreateResponse(HttpStatusCode.NoContent);
                return request.CreateResponse(HttpStatusCode.OK, state);
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }           
        }
        public IEnumerable<State> Get(int countryId, string countryName)
        {
            return objStateBO.GetStates(countryId);
        }

        /// <summary>
        /// This method is used to add new State to the database
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in adding new State to database</exception>
        /// <param name="objState">contians data of new State which is to be added</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all States if HttpStatusCode is OK</returns>
        public HttpResponseMessage Post([FromBody]State objState, HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objStateBO.InsertState(objState);
                return request.CreateResponse(HttpStatusCode.OK, objStateBO.GetStates());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }
        /// <summary>
        /// This method is used to update  existing State in the database
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in updating State in database</exception>
        /// <param name="objState">contians data of existed State which is to be updated</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all States if HttpStatusCode is OK</returns>
        public HttpResponseMessage Put(State objState, HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
                objStateBO.UpdateState(objState);
                return request.CreateResponse(HttpStatusCode.OK, objStateBO.GetStates());
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }            
        }
        /// <summary>
        /// This method is used to delete the State from the database.
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (2-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in deleting State from database</exception>
        /// <param name="id">contains the State Id</param>
        /// <param name="request">contains current request message</param>
        /// <returns>list of all States if HttpStatusCode is OK</returns>
        public HttpResponseMessage Delete(int id, HttpRequestMessage request)
        {
            try
            {
                if (id == 0)
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Bad request.");
                objStateBO.DeleteState(id);
                return request.CreateResponse(HttpStatusCode.OK, objStateBO.GetStates());
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
