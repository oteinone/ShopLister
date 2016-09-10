
using System;
using System.ComponentModel.DataAnnotations;

public class ListItem
{
    public string Id { get; set; }

    [Required]
    public DateTime Created { get; set; }

    [Required]
    public DateTime Updated { get; set; }

    [Required]
    public string Title { get; set; }

    public string Category { get; set; }
}