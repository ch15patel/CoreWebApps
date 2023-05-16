using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

[Keyless]
[Table("JOB_HISTORY")]
public partial class JobHistory
{
    [Column("EMPLOYEE_ID", TypeName = "numeric(6, 0)")]
    public decimal EmployeeId { get; set; }

    [Column("START_DATE", TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Column("END_DATE", TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Column("JOB_ID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? JobId { get; set; }

    [Column("DEPARTMENT_ID", TypeName = "numeric(4, 0)")]
    public decimal? DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    public virtual Department? Department { get; set; }

    [ForeignKey("EmployeeId")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("JobId")]
    public virtual Job? Job { get; set; }
}
