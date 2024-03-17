using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Table("QuestionTable")]
public partial class QuestionTable
{
    [Column("Questionneir_Id")]
    public int? QuestionneirId { get; set; }

    [Key]
    [Column("Question_Id")]
    public int QuestionId { get; set; }

    public string? Tittle { get; set; }
}
