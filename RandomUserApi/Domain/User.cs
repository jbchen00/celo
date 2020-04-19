﻿using System;
using System.Collections.Generic;

namespace RandomUserApi.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<ProfileImage> ProfileImages { get; set; }
    }
}