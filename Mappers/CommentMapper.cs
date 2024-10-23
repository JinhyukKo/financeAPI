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

    public static Comment CreateDtoToEntity(this CreateCommentRequestDto commentDto,int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }

    public static Comment UpdateDtoToEntity(this UpdateCommentRequestDto commentDto, int stockId)
    {
        return new Comment()
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }
}