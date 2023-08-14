using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Domain.Events;

public class PostCreatedEvent: BaseEvent{


    private Post _toPost{get; set;}

    public PostCreatedEvent(Post Post){
        _toPost = Post;
    }

    public Post ToPost{get{return _toPost;}}



}