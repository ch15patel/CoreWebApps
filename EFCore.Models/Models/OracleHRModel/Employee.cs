using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

[Table("EMPLOYEES")]
public partial class Employee
{
    [Key]
    [Column("EMPLOYEE_ID", TypeName = "numeric(6, 0)")]
    public decimal EmployeeId { get; set; }

    [Column("FIRST_NAME")]
    [StringLength(20)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("LAST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(25)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("PHONE_Numeric")]
    [StringLength(20)]
    [Unicode(false)]
    public string PhoneNumeric { get; set; } = null!;

    [Column("HIRE_DATE")]
    public DateTime HireDate { get; set; }

    [Column("JOB_ID")]
    [StringLength(10)]
    [Unicode(false)]
    public string JobId { get; set; } = null!;

    [Column("SALARY", TypeName = "numeric(8, 2)")]
    public decimal Salary { get; set; }

    [Column("COMMISSION_PCT", TypeName = "numeric(2, 2)")]
    public decimal? CommissionPct { get; set; }

    [Column("MANAGER_ID", TypeName = "numeric(6, 0)")]
    public decimal? ManagerId { get; set; }

    [Column("DEPARTMENT_ID", TypeName = "numeric(4, 0)")]
    public decimal? DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    [ForeignKey("JobId")]
    [InverseProperty("Employees")]
    public virtual Job Job { get; set; } = null!;

    [ForeignKey("ManagerId")]
    [InverseProperty("InverseManager")]
    public virtual Employee? Manager { get; set; }
}
