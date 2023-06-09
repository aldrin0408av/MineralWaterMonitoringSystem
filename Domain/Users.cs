﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MineralWaterMonitoring.Domain;

public class Users
{
    [Column("UserId")] public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int RemainingBalance { get; set; }
}