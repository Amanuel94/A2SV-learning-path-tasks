using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Domain.Events;

public class PostRemovedEvent: BaseEvent{


    private Post _toRemove{get; set;}

    public PostRemovedEvent(Post Post){
        _toRemove = Post;
    }

    public Post ToRemove{get{return _toRemove;}}



}