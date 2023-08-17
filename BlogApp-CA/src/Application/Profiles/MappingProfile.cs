using AutoMapper;
using BlogApp_CA.Domain.Entities;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Domain.ValueObjects;

namespace BlogApp_CA.Application.Profiles;

public class MappingProfile:Profile{

    // map is not done based on type since properties in Dtos and actual entities have different types
    public MappingProfile(){
        
        CreateMap<Post, PostDto>()
        .ForMember(dest=>dest.Title, opt=>opt.MapFrom(src=> src.Title.Value))
        .ForMember(dest=>dest.Content, opt=>opt.MapFrom(src=>src.Content.Value));

        CreateMap<PostDto, Post>()
        .ForMember(dest=>dest.Title, opt=>opt.MapFrom(src=> PostTitle.Create(src.Title)))
        .ForMember(dest=>dest.Content, opt=>opt.MapFrom(src=>PostContent.Create(src.Content)));

        CreateMap<Comment, CommentDto>()
        .ForMember(dest=>dest.Text, opt=>opt.MapFrom(src=> src.Text.Value));

        CreateMap<CommentDto, Comment>()
        .ForMember(dest=>dest.Text, opt=>opt.MapFrom(src=> CommentText.Create(src.Text)));

    }

}