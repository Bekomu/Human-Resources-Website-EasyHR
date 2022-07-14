using EasyHR.Attributes;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    [IzinTalep]
    public class IzinTalepEkleViewModel
    {
        [Required(ErrorMessage = "İzin Başlangıç Tarihi boş bırakılamaz.")]
        [Display(Name = "İzin Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        [Remote(action: "IzinTalepTarihValidation", controller: "ClientSideValidation", AdditionalFields = nameof(BitisTarihi))]
        public DateTime? BaslangicTarihi { get; set; }

        [Required(ErrorMessage = "İzin Bitiş Tarihi boş bırakılamaz.")]
        [Display(Name = "İzin Bitiş Tarihi")]
        [DataType(DataType.Date)]
        [Remote(action: "IzinTalepTarihValidation", controller: "ClientSideValidation", AdditionalFields =nameof(BaslangicTarihi))]
        public DateTime? BitisTarihi { get; set; }

        [Display(Name = "İzin Türleri")]
        public IzinTuruEnum IzinTuruEnum { get; set; }
    }
}
