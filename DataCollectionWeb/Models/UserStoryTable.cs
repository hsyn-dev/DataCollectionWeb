using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Table("UserStoryTable")]
public partial class UserStoryTable
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? StoryId { get; set; }

    [Column("storyRecorded")]
    public string? StoryRecorded { get; set; }

    [ForeignKey("StoryId")]
    [InverseProperty("UserStoryTables")]
    public virtual StoryTable? Story { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserStoryTables")]
    public virtual UserTable? User { get; set; }
}
