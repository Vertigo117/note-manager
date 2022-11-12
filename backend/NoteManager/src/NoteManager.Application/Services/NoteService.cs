using AutoMapper;
using NoteManager.Application.Abstractions.Interfaces;
using NoteManager.Application.Contracts;
using NoteManager.Domain.Abstractions.Interfaces.Repositories;
using NoteManager.Domain.Exceptions;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Application.Services;

/// <inheritdoc />
public class NoteService : INoteService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public NoteService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<NoteDto> CreateAsync(NoteUpsertDto note, Guid userId)
    {
        var noteEntity = _mapper.Map<Note>(note);

        var userEntity = await _repositoryManager.UserRepository.FindAsync(userId);

        if (userEntity is null)
        {
            throw new UserNotFoundException(userId);
        }
        
        noteEntity.UserId = userId;

        _repositoryManager.NoteRepository.Add(noteEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        return _mapper.Map<NoteDto>(noteEntity);
    }

    public async Task<NotePageDto> GetAsync(Guid userId, int skip, int take)
    {
        var noteEntityPage =
            await _repositoryManager.NoteRepository.GetEntityPageByExpressionAsync(note => note.UserId == userId, skip,
                take);

        return _mapper.Map<NotePageDto>(noteEntityPage);
    }

    public async Task UpdateAsync(Guid id, NoteUpsertDto note)
    {
        var noteEntity = await _repositoryManager.NoteRepository.FindAsync(id);

        if (noteEntity is null)
        {
            throw new NoteNotFoundException(id);
        }

        _mapper.Map(note, noteEntity);
        
        _repositoryManager.NoteRepository.Update(noteEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var noteEntity = await _repositoryManager.NoteRepository.FindAsync(id);

        if (noteEntity is null)
        {
            throw new NoteNotFoundException(id);
        }
        
        _repositoryManager.NoteRepository.Remove(noteEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}