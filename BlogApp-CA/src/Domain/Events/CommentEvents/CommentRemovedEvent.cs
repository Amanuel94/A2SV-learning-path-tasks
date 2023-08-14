using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Domain.Events;

public class CommentRemovedEvent: BaseEvent{


    private Comment _toRemove{get; set;}

    public CommentRemovedEvent(Comment Comment){
        _toRemove = Comment;
    }

    public Comment ToRemove{get{return _toRemove;}}



}