using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Table("User_Question_AnswreTable")]
public partial class UserQuestionAnswreTable
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? QuestionId { get; set; }

    [Column("answer")]
    public int? Answer { get; set; }
}
