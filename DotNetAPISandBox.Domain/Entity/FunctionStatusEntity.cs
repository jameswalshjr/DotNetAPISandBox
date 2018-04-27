using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetAPISandBox.Domain.Entity
{
    public class FunctionStatusEntity
    {
        [Key]
        [Column("FunctionStatusId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FunctionStatusId { get; set; }

        [Column("FunctionName")]
        [MaxLength(100)]
        [Required]
        public string FunctionName { get; set; }

        [Column("FunctionDescription")]
        [MaxLength(250)]
        public string FunctionDescription { get; set; }

        [Column("EnableFunction")]
        [Required]
        public bool EnableFunction { get; set; }
    }
}
