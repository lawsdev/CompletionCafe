using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Accomplishment 
{

    [Key]
    public int ID { get; set; }
    public string Category { get; set; }
    //category should be user defined
    public bool Status { get; set; }

    [Required(ErrorMessage = "MM/DD/YYYY")]
    [RegularExpression(@"^(?:[0][1-9]|[1-9]|[1][0-2])[-/](?:[0][1-9]|[1-9]|[12][0-9]|3[01])[-/](?:[2][0][0-9][0-9]|[0-9][0-9]\b)",
    ErrorMessage = "Invalid Date Format")]
    public string Date { get; set; }

    public string? DaysLeft { get; set; }

    public string? Description { get; set; }
    public string? Notes { get; set; } 

}

public class UserCategory
{
    [Key]
    public string UserDefinedCategory { get; set; }
}




