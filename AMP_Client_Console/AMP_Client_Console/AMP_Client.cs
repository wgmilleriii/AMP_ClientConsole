using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;
using Amplifier_Helpers;

namespace AMP_Client_Console
{
    class AMP_Client
    {
        // MongoDB identifier
        public ObjectId _id { get; set; }

        private string _email;
        private string _password;
        private string _firstName;
        private string _lastName;

        /// <summary>
        /// Gets or sets the email address of the client.  
        /// </summary>
        /// <value>Email address.</value>
        /// <remarks> The value must be a valid email address.</remarks>
        /// <exception cref="Exception.Exception">Thrown when a missing or invalid 
        /// email address is assigned.</exception>
        public string email {
            
            get {
                return _email ;
                
            }
            set {
               _email = AMP_DataCleanse.SetIfIsEmail(value);
            }
        }

        /// <summary>
        /// Gets or sets the password of the client.  
        /// </summary>
        /// <value>Password.</value>
        /// <remarks> The value must be given.</remarks>
        /// <exception cref="Exception.Exception">Thrown when a missing 
        /// value is assigned.</exception>

        public string password {
            get {
                return _password;
            }
            set {
                _password = AMP_DataCleanse.SetIfExists(value);
            }
        }

        /// <summary>
        /// Gets or sets the first name of the client.  
        /// </summary>
        /// <value>First Name.</value>
        /// <remarks> The value must be given.</remarks>
        /// <exception cref="Exception.Exception">Thrown when a missing 
        /// value is assigned.</exception>

        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = AMP_DataCleanse.SetIfExists(value);
            }

        }
        /// <summary>
        /// Gets or sets the last name of the client.  
        /// </summary>
        /// <value>Last Name.</value>
        /// <remarks> The value is optional.</remarks>

        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value ?? "";
            }

        }
    }

}
