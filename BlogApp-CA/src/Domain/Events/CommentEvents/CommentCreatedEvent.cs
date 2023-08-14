using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Domain.Events;

public class CommentCreatedEvent: BaseEvent{


    private Comment _toComment{get; set;}

    public CommentCreatedEvent(Comment Comment){
        _toComment = Comment;
    }

    public Comment ToComment{get{return _toComment;}}



}