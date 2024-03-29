﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Table("UserStoryTable")]
public partial class UserStoryTable
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? StoryId { get; set; }

    public string? StoryRecorded { get; set; }
}
