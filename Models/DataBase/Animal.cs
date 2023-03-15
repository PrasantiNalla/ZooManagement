
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SpeciesId { get; set; }// foreign key to Species table
        public Species Species { get; set; } // navigation property
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateAcquired { get; set; }

    }
}
