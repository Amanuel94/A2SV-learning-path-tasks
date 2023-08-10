using AutoMapper;
using BloggingApp.Models;
namespace BloggingApp.Mapping;
public static class MapperConfig{

    public static Mapper Mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<Comment, CommentDto>();

            }));
}