using System;

namespace RandomUserApi.Data.Entities
{
    public class ProfileImageEntity
    {
        public Guid Id { get; set; }
        public string Thumbnail { get; set; }
        public string Large { get; set; }
        public virtual UserEntity User { get; set; }
    }
}