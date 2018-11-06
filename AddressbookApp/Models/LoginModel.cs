using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressbookApp.Models
{
    /// <summary>
    /// This class is used for maintaining Login User Details.
    /// </summary>
    /// <remarks>
    /// Date Created: 4th Nov 2016
    /// Edited By: Phani (4-11-2016 )
    /// </remarks>
    public class LoginModel
    {
        #region Public Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        #endregion
    }
}