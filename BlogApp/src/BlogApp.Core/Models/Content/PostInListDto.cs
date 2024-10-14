using BlogApp.Core.Domain.Content;

using System.ComponentModel.DataAnnotations;

using AutoMapper;

namespace BlogApp.Core.Models.Content
{
    public class PostInListDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? Thumbnail { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Post, PostInListDto>();
            }
        }
    }
}