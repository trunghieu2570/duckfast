﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DuckFast.Web.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Slug { get; set; }
        public string? Description { get; set; }
    }
}
