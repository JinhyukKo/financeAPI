using System.ComponentModel.DataAnnotations;

namespace FinSharkk.DTOs.Comment;

public class UpdateCommentRequestDto
{   [Required]
    [MinLength(3,ErrorMessage = "Oops Title must be at least 3 characters long.")]
    [MaxLength(20, ErrorMessage = "Oops Title must be no more than 20 characters long.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(3,ErrorMessage = "Content must be at least 3 characters long.")]
    [MaxLength(20, ErrorMessage = "Content must be no more than 20 characters long.")]
    public string Content { get; set; } = string.Empty;
}