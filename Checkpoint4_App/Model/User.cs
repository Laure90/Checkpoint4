﻿using System;

namespace Checkpoint4_App
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool StaffMember { get; set; }
    }
}
