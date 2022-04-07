﻿using System.ComponentModel.DataAnnotations;

namespace ExampleJwtApp.Front.Models
{
    public class CategoryCreateRequestModel
    {
        [Required(ErrorMessage ="Kategori Adı Boş Olamaz")]
        public string? Definition { get; set; }
    }
}
