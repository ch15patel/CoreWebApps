using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

[Table("LOCATIONS")]
public partial class Location
{
    [Key]
    [Column("LOCATION_ID", TypeName = "numeric(4, 0)")]
    public decimal LocationId { get; set; }

    [Column("STREET_ADDRESS")]
    [StringLength(40)]
    [Unicode(false)]
    public string StreetAddress { get; set; } = null!;

    [Column("POSTAL_CODE")]
    [StringLength(12)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [Column("CITY")]
    [StringLength(30)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("STATE_PROVINCE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? StateProvince { get; set; }

    [Column("COUNTRY_ID")]
    [StringLength(2)]
    [Unicode(false)]
    public string? CountryId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("Locations")]
    public virtual Country? Country { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
