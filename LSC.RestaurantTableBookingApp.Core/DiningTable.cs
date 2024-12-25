using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSC.RestaurantTableBookingApp.Core;

public partial class DiningTable
{
    [Key]
    public int Id { get; set; }

    public int RestaurantBranchId { get; set; }

    [StringLength(100)]
    public string? TableName { get; set; }

    public int Capacity { get; set; }

    public virtual RestaurantBranch Branch { get; set; } = null!;

    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new HashSet<TimeSlot>();
}
