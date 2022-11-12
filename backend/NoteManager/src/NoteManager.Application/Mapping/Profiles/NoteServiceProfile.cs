using AutoMapper;
using NoteManager.Application.Contracts;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Application.Mapping.Profiles;

internal class NoteServiceProfile : Profile
{
    public NoteServiceProfile()
    {
        CreateMap<NoteUpsertDto, Note>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateDate, opt => opt.Ignore());

        CreateMap<Note, NoteDto>();
    }
}