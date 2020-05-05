using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerCRUDSample.Shared.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
