using System;
using System.Collections.Generic;

namespace data;

public partial class Reservation
{
    public int Id { get; set; }

    public int FlightId { get; set; }

    public int PassangerId { get; set; }

    public DateTime ReservationDate { get; set; }
}
