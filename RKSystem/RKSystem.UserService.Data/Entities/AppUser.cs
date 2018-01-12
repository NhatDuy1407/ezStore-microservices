using System;
using RKSystem.Core.Utils;
using RKSystem.DataAccess.MongoDB.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Data.Entities
{
    public class AppUser : BaseGuidEntity<AppUserDto>
    {
        protected override void UpdateDomain(AppUserDto data, string userId)
        {
            UserName = data.UserName;
            FullName = data.FullName;
            Email = data.Email;
            IsActive = data.IsActive;
            CreatedDate = DateTime.Now;
            PasswordHash = CryptographyUtils.HashPassword(data.Password);
            SecurityStamp = "";
        }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool IsActive { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string ActivationCode { get; set; }

        public string ForgotPasswordCode { get; set; }
    }
}