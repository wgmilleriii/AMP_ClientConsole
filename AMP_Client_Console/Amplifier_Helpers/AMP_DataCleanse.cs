using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amplifier_Helpers
{
    public static class AMP_DataCleanse
    {
        private static AMP_Validation_Result _result;

        /// <summary>
        /// If the value exists, return it.  Otherwise, throw a AMP_Validation_Result error.
        /// </summary>
        public static string SetIfExists(string s)
        {
            _result = AMP_Validator.Exists(s);
            if (!_result.valid)
            {
                throw new Exception(_result.error_message);
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// If the value is a valid email address, return it.  Otherwise, throw a AMP_Validation_Result error.
        /// </summary>
        public static string SetIfIsEmail(string s)
        {
            _result = AMP_Validator.IsEmail(s);
            if (!_result.valid)
            {
                throw new Exception(_result.error_message);
            }
            else
            {
                return s;
            }
        }

    }
}
