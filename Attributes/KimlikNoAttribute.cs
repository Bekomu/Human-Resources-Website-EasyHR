using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class KimlikNoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            string tcNo = (string)value;

            long rakamlar;
            bool rakamMi = long.TryParse(tcNo, out rakamlar);
            if (!rakamMi)
            {
                return new ValidationResult("TC kimlik no sadece rakamlardan oluşmalıdır.");
            }

            if (tcNo.Length < 11 || tcNo[0].ToString() == "0")
            {
                return new ValidationResult("TC kimlik no 0(sıfır) ile başlayamaz ve 11 haneden oluşmalıdır.");
            }
            if (tcNo.Length == 11)
            {


                int tekToplam = 0;
                for (int i = 0; i <= 8; i += 2)
                {
                    tekToplam += Convert.ToInt32(tcNo[i].ToString());
                }

                int ciftToplam = 0;
                for (int i = 1; i <= 7; i += 2)
                {
                    ciftToplam += Convert.ToInt32(tcNo[i].ToString());
                }
                int basamakOn = ((tekToplam * 7 - ciftToplam) % 10);
                if (basamakOn != Convert.ToInt32(tcNo[9].ToString()))
                {
                    return new ValidationResult("Geçerli bir TC kimlik no giriniz.");
                }

                int ilkOnHaneToplam = 0;
                for (int i = 0; i < tcNo.Length - 1; i++)
                {
                    ilkOnHaneToplam += Convert.ToInt32(tcNo[i].ToString());
                }
                if (ilkOnHaneToplam % 10 != Convert.ToInt32(tcNo[10].ToString()))
                {
                    return new ValidationResult("Geçerli bir TC kimlik no giriniz.");
                }
            }
            return ValidationResult.Success;

        }


    }
}
