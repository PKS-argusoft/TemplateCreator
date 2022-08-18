
using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

    public class Template
    {
        [Key]
        [Identity]
        public int TemplateId { get; set; }
        [Required]
        public string TemplateName { get; set; } = string.Empty;
        [Required]
      
        public int Order { get; set; } = 0;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public int CreatedBy { get; set; } = -1;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public int UpdatedBy { get; set; } = -1;

    }

