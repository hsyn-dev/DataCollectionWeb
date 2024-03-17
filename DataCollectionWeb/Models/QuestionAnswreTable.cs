using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

[Keyless]
[Table("QuestionAnswretable")]
public partial class QuestionAnswretable
{
    public int? QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public string? Tittle { get; set; }
}
