using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Table("UserTable")]
public partial class UserTable
{
    [Key]
    [Column("User_Id")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string? Age { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    [StringLength(200)]
    public string? Lof { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserStoryTable> UserStoryTables { get; set; } = new List<UserStoryTable>();
}
