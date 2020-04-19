using System;

namespace RandomUserApi.Data.Entities
{
    public class ProfileImageEntity
    {
        public string Thumbnail { get; set; }
        public string Large { get; set; }
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public Guid Id { get; set; }
    }
}