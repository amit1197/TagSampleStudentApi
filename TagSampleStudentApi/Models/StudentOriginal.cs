using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TagSampleStudentApi.Models;

public partial class StudentOriginal
{
    [Required(ErrorMessage = "Student Id is necessary")]
    [Range(1, 10)]
    public string StudentId { get; set; } = null!;

    [Required]
    [StringLength(1)]
    public string Gender { get; set; } = null!;

    [Required]
    public string NationalIty { get; set; } = null!;

    [Required]
    public string PlaceofBirth { get; set; } = null!;

    [Required]
    public string StageId { get; set; } = null!;

    [Required]
    public decimal GradeId { get; set; }

    [Required]
    public string SectionId { get; set; } = null!;

    [Required]
    public string Topic { get; set; } = null!;

    [Required]
    public string Semester { get; set; } = null!;

    [Required]
    public string Relation { get; set; } = null!;

    [Required]
    public byte Raisedhands { get; set; }

    [Required]
    public byte VisItedResources { get; set; }

    [Required]
    public byte AnnouncementsView { get; set; }

    [Required]
    public byte Discussion { get; set; }

    [Required]
    public bool ParentAnsweringSurvey { get; set; }

    [Required]
    public string ParentschoolSatisfaction { get; set; } = null!;

    [Required]
    public string StudentAbsenceDays { get; set; } = null!;

    [Required]
    public byte StudentMarks { get; set; }

    [Required]
    public string Class { get; set; } = null!;
}
