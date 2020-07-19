using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DatabaseModel
{
    public class UserVoting: IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ProductVotingId { get; set; }
        public ProductVoting ProductVoting { get; set; }
        public Guid? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}