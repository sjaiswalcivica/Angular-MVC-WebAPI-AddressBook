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
    /// Class for maintaining business login of UserDetails module
    /// </summary>
    /// <remarks>
    /// DateCreated: 24th Oct 2016
    /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
    /// </remarks>
    public class UserDetailsBO
    {
        #region Initialization
        UserDetailsRepository objUserDetailsRepository = new UserDetailsRepository();
        #endregion

        #region Public Methods
        /// <summary>
        /// This method is used for retrieveing All User Details
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <returns>List of UserDetail</returns>
        public IEnumerable<Userdetail> GetUserDetails()
        {
            return objUserDetailsRepository.GetUserDetails();
        }
        /// <summary>
        /// This method is used for retrieving UserDetail based on UserDetail Id
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="id">contains UserDetail Id</param>
        /// <returns>UserDetail</returns>
        public Userdetail GetById(int id)
        {
            return objUserDetailsRepository.GetById(id);
        }
        /// <summary>
        /// This method is used for Inserting new User 
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks> 
        /// <param name="userDetail">contains details of new user</param>
        public void InsertUserDetail(Userdetail userDetail)
        {
            objUserDetailsRepository.InsertUserDetail(userDetail);
        }
        /// <summary>
        /// This method is used for updating user details
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="userDetail">contains details of existed user</param>
        public void UpdateUserDetail(Userdetail userDetail)
        {
            objUserDetailsRepository.UpdateUserDetail(userDetail);
        }
        /// <summary>
        /// This method is used for deleting user
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="id">contains user id</param>
        public void DeleteUserDetail(int id)
        {
            objUserDetailsRepository.DeleteUserDetail(id);
        }
        /// <summary>
        /// This method is used for Authenticating User
        /// </summary>
        /// <remarks>
        /// DateCreated: 24th Oct 2016
        /// Edited By: Rakesh (25-Oct-2016) , Phani (3-Nov-2016)
        /// </remarks>
        /// <param name="userName">contains login username</param>
        /// <param name="password">contains login password</param>
        /// <returns>UserDetail based on Username and password</returns>
        public Userdetail AuthenticateUser(string userName, string password)
        {
            return objUserDetailsRepository.AuthenticateUser(userName, password);
        }
        #endregion
    }
}
