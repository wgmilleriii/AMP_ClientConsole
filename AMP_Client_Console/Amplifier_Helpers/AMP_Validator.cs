using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Amplifier_Helpers
{
    /// <summary>
    /// Simple validation result.  It's simple.
    /// </summary>
    class AMP_Validation_Result {
        public bool valid = true;
        public string error_message = "";
    }
    
    static class AMP_Validator
    {

        /// <summary>
        /// Validates a value exists.
        /// </summary>
        public static AMP_Validation_Result Exists (string s)
        {
            AMP_Validation_Result r = new AMP_Validation_Result();
            r.valid=!(String.IsNullOrEmpty(s));

            if (!r.valid) r.error_message = "This field is required.";

            return r;
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        public static AMP_Validation_Result IsEmail(string s)
        {
            AMP_Validation_Result r = new AMP_Validation_Result();
            r = Exists(s);
            if (r.valid)
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                r.valid = re.IsMatch(s);

                if (!r.valid) r.error_message = "This is not a valid email address";
            }
            return r;
        }

    }
}
