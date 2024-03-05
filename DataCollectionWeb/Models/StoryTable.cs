using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Table("StoryTable")]
public partial class StoryTable
{
    [Key]
    [Column("Story_ID")]
    public int StoryId { get; set; }

    public string? Tittle { get; set; }

    public string? Description { get; set; }

    [Column("Time_Limited")]
    public string? TimeLimited { get; set; }

    public string? AudioName { get; set; }

    [InverseProperty("Story")]
    public virtual ICollection<UserStoryTable> UserStoryTables { get; set; } = new List<UserStoryTable>();
}
