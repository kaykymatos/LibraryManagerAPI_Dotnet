﻿using Library.Project.API.Models.DTO.Get;
using Library.Project.API.Models.DTO.Post;
using Library.Project.API.Models.DTO.Put;
using Library.Project.API.Models.Entities;

namespace Library.Project.API.Interfaces.Service
{
    public interface IAuthorService : IBaseService<AuthorEntity, AuthorDTOPut, AuthorDTOPost, AuthorDTOGet>
    {
    }
}
