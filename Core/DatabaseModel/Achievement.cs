using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Attributes;

namespace Core.DatabaseModel
{
    public class Achievement: IUpdateableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string Name { get; set; }
        public int SnackPoints { get; set; }
        public byte[] Image { get; set; }
        public Guid? AchievementGroupId { get; set; }
        public AchievementGroup AchievementGroup { get; set; }
        public bool CanBeAwardedMultipleTimes { get; set; }
        [NonPublicData]
        public List<UserAchievement> UserAchievements { get; set; }
    }
}