using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

[Table("DEPARTMENTS")]
public partial class Department
{
    [Key]
    [Column("DEPARTMENT_ID", TypeName = "numeric(4, 0)")]
    public decimal DepartmentId { get; set; }

    [Column("DEPARTMENT_NAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string DepartmentName { get; set; } = null!;

    [Column("MANAGER_ID", TypeName = "numeric(6, 0)")]
    public decimal? ManagerId { get; set; }

    [Column("LOCATION_ID", TypeName = "numeric(4, 0)")]
    public decimal? LocationId { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("LocationId")]
    [InverseProperty("Departments")]
    public virtual Location? Location { get; set; }
}
