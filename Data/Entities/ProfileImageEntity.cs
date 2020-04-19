using System;

namespace Data.Entities
{
    public class ProfileImageEntity
    {
        public Guid Id { get; set; }
        public string Thumbnail { get; set; }
        public string Large { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}