﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Seguranca
{
    public class OpcaoToken
    {
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string  Audience { get; set; }
        public DateTime NotBefore { get; set; } = DateTime.UtcNow;
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(30);
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public Func<Task<string>> JtiGenerator =>
            () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }

    }
}
