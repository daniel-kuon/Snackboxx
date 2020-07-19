using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Core.DatabaseModel
{
    public class ApplicationUser : IdentityUser<Guid>, ISensitiveDataEntity, IUpdateableEntity
    {
        [NonPublicData] public decimal AlertLimit { get; set; }
        [NonPublicData] public List<Sale> Sales { get; set; }
        [NonPublicData] public List<UserBarcode> Barcodes { get; set; }
        [NonPublicData] public List<Payment> Payments { get; set; }
        [NonPublicData] public bool ProductBarcodesEnabled { get; set; }
        [NonPublicData] public bool TimeTrackingEnabled { get; set; }
        [NonPublicData] public int Level { get; set; }
        [NonPublicData] public List<UserAchievement> Achievements { get; set; }
        [NonPublicData] public List<UserVoting> UserVotings { get; set; }

        [NonPublicData] public List<TimeEntry> TimeEntries { get; set; }

        public void CleanSensitiveData()
        {
            Id = new Guid();
            Email = null;
            NormalizedEmail = null;
            EmailConfirmed = false;
            PasswordHash = null;
            SecurityStamp = null;
            ConcurrencyStamp = null;
            PhoneNumber = null;
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            LockoutEnd = null;
            LockoutEnabled = false;
            AccessFailedCount = 0;
        }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}