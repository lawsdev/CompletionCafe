using System.ComponentModel.DataAnnotations;

public class Accomplishment 
{
    [Key]
    public int ID { get; set; }
    public string Category { get; set; }
    //category should be user defined
    public bool Status { get; set; }
    public int Date { get; set; }
    //regex expression ^^
    public string Description { get; set; }
    public string Notes { get; set; }   
}