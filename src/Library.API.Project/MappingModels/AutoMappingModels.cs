using AutoMapper;
using Library.Project.API.Models.DTO.Get;
using Library.Project.API.Models.DTO.Post;
using Library.Project.API.Models.DTO.Put;
using Library.Project.API.Models.Entities;

namespace Library.Project.API.MappingModels
{
    public class AutoMappingModels : Profile
    {
        public AutoMappingModels()
        {
            #region Post
            CreateMap<UserDTOPost, UserEntity>();
            CreateMap<AuthorDTOPost, AuthorEntity>();
            CreateMap<BookDTOPost, BookEntity>();
            #endregion

            #region Put
            CreateMap<UserDTOPut, UserEntity>();
            CreateMap<AuthorDTOPut, AuthorEntity>();
            CreateMap<BookDTOPut, BookEntity>();
            #endregion

            #region Get
            CreateMap<UserEntity, UserDTOGet>();
            CreateMap<AuthorEntity, AuthorDTOGet>();
            CreateMap<BookEntity, BookDTOGet>();
            #endregion


        }
    }
}
