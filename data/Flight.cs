using System;
using System.Collections.Generic;

namespace data;

public partial class Flight
{
    public int Id { get; set; }

    public string FlightNumber { get; set; } = null!;

    public string ArrivalAirport { get; set; } = null!;

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public int AvailableSeats { get; set; }
}
