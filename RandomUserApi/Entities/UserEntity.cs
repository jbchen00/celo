using System;
using System.Collections.Generic;

namespace RandomUserApi.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<ProfileImageEntity> ProfileImages { get; set; }
    }
}