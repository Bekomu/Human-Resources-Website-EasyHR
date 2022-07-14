using EasyHR.Data;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace EasyHR.Models.ViewModels
{
    public class PersonelListeleViewModel
    {
        public List<ApplicationUser> Personeller { get; set; }
    }
}
