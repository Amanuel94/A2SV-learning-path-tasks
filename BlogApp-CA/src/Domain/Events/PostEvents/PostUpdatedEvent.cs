using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Domain.Events;

public class PostUpdatedEvent: BaseEvent{


    private Post _toUpdate{get; set;}

    public PostUpdatedEvent(Post Post){
        _toUpdate = Post;
    }

    public Post ToUpdate{get{return _toUpdate;}}



}