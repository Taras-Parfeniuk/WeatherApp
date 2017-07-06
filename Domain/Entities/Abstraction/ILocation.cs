﻿using Domain.Entities.Location;

namespace Domain.Entities.Abstraction
{
    public interface ILocation
    {
        int? Id { get; set; }
        string Name { get; set; }
        Coordinates Coordinates { get; set; }
    }
}
