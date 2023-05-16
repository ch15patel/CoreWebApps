using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

[Table("REGIONS")]
public partial class Region
{
    [Key]
    [Column("REGION_ID", TypeName = "numeric(18, 0)")]
    public decimal RegionId { get; set; }

    [Column("REGION_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string RegionName { get; set; } = null!;

    [InverseProperty("Region")]
    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
