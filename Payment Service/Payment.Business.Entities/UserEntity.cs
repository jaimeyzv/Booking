using System;

namespace Stamping.Business.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string IdentityDocumentType { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }
        public bool IsActive { get; set; }
        public int AssignedMobileId { get; set; }
        public int RegionalTeamId { get; set; }
    }
}