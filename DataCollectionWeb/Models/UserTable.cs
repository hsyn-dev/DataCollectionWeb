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
    [Required(ErrorMessage ="این فیلد اجباری است .")]
    public string? Age { get; set; }
    [Required(ErrorMessage = "این فیلد اجباری است .")]

    [StringLength(50)]
    public string? Gender { get; set; }

    [StringLength(200)]
    [Required(ErrorMessage = "این فیلد اجباری است .")]

    public string? Lof { get; set; }

    public bool? Iscomplete { get; set; }
}
