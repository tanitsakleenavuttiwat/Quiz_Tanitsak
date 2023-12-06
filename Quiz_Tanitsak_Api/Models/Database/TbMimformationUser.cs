using System;
using System.Collections.Generic;

namespace Quiz_Tanit_API.Models.Database;

public partial class TbMimformationUser
{
    public int UserId { get; set; }

    public string? Firstname { get; set; }

    public string? LastName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
