﻿using System;

namespace ROH.StandardModels.Account
{
    public class UserModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? Guid { get; set; }
    }
}
