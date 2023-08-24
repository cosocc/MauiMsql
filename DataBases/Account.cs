using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiMsql.DataBases;


[Table("t_admin")]
public class Admin
{
    [Key]
    public string f_name { get; set; }
    public string f_pass { get; set; }
    public int f_prior { get; set; }
}

