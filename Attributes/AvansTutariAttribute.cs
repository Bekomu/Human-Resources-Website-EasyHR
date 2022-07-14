using EasyHR.Models;
using EasyHR.Models.Context;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class AvansTutariAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }

        //public AvansTutariAttribute(decimal maas)
        //{
        //    _maas = maas;
        //}

        //public decimal _maas { get; }

        //// TODO : Avans tutari attribute
        //public override bool IsValid(object value)
        //{
        //    var avansTutari = (decimal)value;

        //    if (!(avansTutari < _maas * 0.3m && avansTutari > _maas * 0.1m))
        //    {
        //        ErrorMessage = "Avans tutarı maaşınızın %10 undan küçük, %30 undan büyük olamaz.";
        //        return false;
        //    }
        //    return true;
        //}
    }
}
