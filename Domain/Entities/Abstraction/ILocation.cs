using Domain.Entities.Location;

namespace Domain.Entities.Abstraction
{
    public interface ILocation
    {
        int? Id { get; set; }
        Coordinates Coordinates { get; set; }
    }
}
