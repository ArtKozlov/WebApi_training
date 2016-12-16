using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TaskManagerProvider.Attributes
{
    [AttributeUsage(AttributeTargets.Property |AttributeTargets.Field)]
    public class CustomStringLengthAttribute : ValidationAttribute
    {
        readonly int _maxLength;

        public int MaxLength
        {
            get { return _maxLength; }
        }

        public CustomStringLengthAttribute(int maxLength)
        {
            _maxLength = maxLength;
        }


        public override bool IsValid(object value)
        {
            var @string = (String)value;
            bool result = false;
            if (@string != null)
            {
                if(@string.Length < MaxLength)
                    result = true;
            }
            return result;
        }
        

        public override string FormatErrorMessage(string value)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, value, MaxLength);
        }
    }
}