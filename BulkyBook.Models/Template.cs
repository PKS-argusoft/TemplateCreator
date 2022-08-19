
using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

    public class Template
    {
        [Key]
        public int TemplateId { get; set; }
        [Required]
        public string TemplateName { get; set; }
        
        public int Order { get; set; } 
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int CreatedBy { get; set; } 
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int UpdatedBy { get; set; } = -1;

    }

