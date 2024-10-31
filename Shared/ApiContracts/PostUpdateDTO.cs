using System.ComponentModel.DataAnnotations;

namespace ApiContracts;

public class PostUpdateDTO
{
    [Required]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }

    [Required]
    public string Body { get; set; }
}