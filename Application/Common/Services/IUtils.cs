﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public interface IUtils
    {
        public string GenerateVerificationToken();
    }
}
