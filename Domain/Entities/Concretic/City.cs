using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Concretic
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public City() { }
    }
}
