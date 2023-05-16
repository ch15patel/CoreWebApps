using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

[Table("JOBS")]
public partial class Job
{
    [Key]
    [Column("JOB_ID")]
    [StringLength(10)]
    [Unicode(false)]
    public string JobId { get; set; } = null!;

    [Column("JOB_TITLE")]
    [StringLength(35)]
    [Unicode(false)]
    public string JobTitle { get; set; } = null!;

    [Column("MIN_SALARY", TypeName = "numeric(6, 0)")]
    public decimal MinSalary { get; set; }

    [Column("MAX_SALARY", TypeName = "numeric(6, 0)")]
    public decimal MaxSalary { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
