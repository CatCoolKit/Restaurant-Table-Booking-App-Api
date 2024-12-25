using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSC.RestaurantTableBookingApp.Core;

public partial class TimeSlot
{
    [Key]
    public int Id { get; set; }

    public int DiningTableId { get; set; }

    [Required]
    public DateTime ReservationDay { get; set; }

    [Required]
    [StringLength(100)]
    public string MealType { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string TableStatus { get; set; } = null!;

    public virtual DiningTable DiningTable { get; set; } = null!;

    [InverseProperty("TimeSlot")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
