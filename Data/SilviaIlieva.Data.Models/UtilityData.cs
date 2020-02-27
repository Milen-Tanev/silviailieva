namespace SilviaIlieva.Data.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UtilityData : IEntity, IDeletable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
