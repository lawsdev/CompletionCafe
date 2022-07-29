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
    public bool Status { get; set; }

    //REGEX Date input
    [Required(ErrorMessage = "MM/DD/YYYY")]
    [RegularExpression(@"^(?:[0][1-9]|[1-9]|[1][0-2])[-/](?:[0][1-9]|[1-9]|[12][0-9]|3[01])[-/](?:[2][0][0-9][0-9]|[0-9][0-9]\b)",
    ErrorMessage = "Invalid Date Format")]
    public DateTime date;

    public string Date{
        get {
            return date.ToString("d");
        }
        set {
            date = DateTime.Parse(value);
        }
    }

    public string? Description { get; set; }
    public string? Notes { get; set; } 

    public string? _daysLeft;
    public string DaysLeft => _daysLeft ??= GetDaysLeft();

    public string GetDaysLeft(){   
    _daysLeft = (date - DateTime.Now).Days.ToString();
    return _daysLeft;
    }


}

