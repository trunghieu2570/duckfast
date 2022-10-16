using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DuckFast.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
    }
}
