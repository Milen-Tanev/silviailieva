namespace SilviaIlieva.Data.Models.Abstract
{
    using Contracts;
    using System.ComponentModel.DataAnnotations;

    public abstract class Design : IEntity, INameable, IDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
