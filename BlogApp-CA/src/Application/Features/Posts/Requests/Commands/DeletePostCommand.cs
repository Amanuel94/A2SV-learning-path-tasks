using AutoMapper;
using BlogApp_CA.Application.Repositories;
using MediatR;

public class DeletePostCommand : IRequest
{
    public int Id;

    public DeletePostCommand(int id)
    {
        Id = id;
    }


}