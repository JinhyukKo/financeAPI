using FinSharkk.DTOs.Comment;
using FinSharkk.Models;

namespace FinSharkk.Mappers;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            StockId = comment.StockId,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
        };
    }

    // public static Comment ToEntity(CommentDto commentDto)
    // {
    //     return new Comment()
    //     {
    //         StockId = commentDto.StockId,
    //         Id = commentDto.Id,
    //         Title = commentDto.Title,
    //         Content = commentDto.Content,
    //         CreatedOn = commentDto.CreatedOn,
    //     };
    // }
}