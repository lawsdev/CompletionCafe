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
    public int Date { get; set; }
    //regex expression ^^s
    public string? Description { get; set; }
    public string? Notes { get; set; }   

}

public class UserCategory
{
    [Key]
    public string UserDefinedCategory { get; set; }
}

public class Dt 
{
    [Key]
    public DateTime Dtview { get; set; }
}