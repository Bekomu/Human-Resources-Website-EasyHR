using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class ZorunluAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string deger)
        {
            return !String.IsNullOrEmpty(ErrorMessage) ? ErrorMessage : $"{deger} alanı zorunludur.";
        }
    }
}
