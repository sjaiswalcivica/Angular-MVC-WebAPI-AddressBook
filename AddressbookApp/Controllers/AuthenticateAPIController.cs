using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressbookApp.Models;
using AddressbookApp.Utility;
using System.Web.Security;
using AddressbookApp.BO;
using System.Web;

namespace AddressbookApp.Controllers
{
    /// <summary>
    /// This Api is used for Authenticating Users
    /// </summary>
    /// <remarks>
    /// DateCreated: 4th Nov 2016
    /// Edited By: Phani (5-Nov-2016)
    /// </remarks>
    [RoutePrefix("api/AuthenticateAPI")]
    public class AuthenticateAPIController : ApiController
    {
        #region Initialization
        UserDetailsBO objUserDetailBO = new UserDetailsBO();
        #endregion

        #region Public Methods
        // GET: api/AuthenticateAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AuthenticateAPI/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// This method is used for authenticating User details and returning user data in string format
        /// </summary>
        /// <remarks>
        /// DateCreated: 4th Nov 2016
        /// Edited By: Phani (5-Nov-2016)
        /// </remarks>
        /// <exception cref="HttpResponseException">Will be thrown when there is a problem in Retrieving data of user or any exception occurs due to Helper Properties</exception>
        /// <param name="model">contains current user login details</param>
        /// <param name="request">contains currrent request message</param>
        /// <returns>user data</returns>
        // POST: api/AuthenticateAPI
        public HttpResponseMessage Post([FromBody]LoginModel model,HttpRequestMessage request)
        {
            try
            {
                //if login user is admin
                if (model.UserName.ToLower() == "admin" && model.Password.ToLower() == "admin")
                {
                    string UserData = string.Empty;
                    UserData = model.UserName.ToLower() + "^" + model.Password.ToLower();
                    FormsAuthentication.SetAuthCookie(UserData, Convert.ToBoolean(model.RememberMe));
                    return request.CreateResponse(HttpStatusCode.OK, UserData);
                }
                //if login user is not admin
                else
                {
                    //retrieving userdetails based on username and password
                    Userdetail userdetail = objUserDetailBO.AuthenticateUser(model.UserName, model.Password);
                    if (userdetail != null)
                    {
                        //setting user details in helper properties
                        string UserData = string.Empty;
                        UserData = userdetail.PKUserId + "^" + userdetail.UserName + "^" + "User";
                        //creating auth cookie for login user
                        FormsAuthentication.SetAuthCookie(UserData, Convert.ToBoolean(model.RememberMe));
                        return request.CreateResponse(HttpStatusCode.OK, UserData);
                    }
                    else
                        return request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(ex.Message), ReasonPhrase = ex.Message };
                throw new HttpResponseException(resp);
            }
        }

        [Route("Logout")]
        // PUT: api/AuthenticateAPI/5
        public void Logout(HttpRequestMessage request)
        {
            //if (Request.IsAuthenticated)
            //{
            //    FormsAuthentication.SignOut();
            //}
            //return request.RedirectToAction("LogOn");
        }

        // DELETE: api/AuthenticateAPI/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
