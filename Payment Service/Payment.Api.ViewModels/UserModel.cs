using System;
using System.ComponentModel.DataAnnotations;

namespace Stamping.Api.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [MaxLength(6, ErrorMessage = "UserName debe tener 6 caracteres!")]
        [MinLength(6, ErrorMessage = "UserName debe tener 6 caracteres!")]
        public string UserName { get; set; }
        [MaxLength(6, ErrorMessage = "Password debe tener 6 caracteres!")]
        [MinLength(6, ErrorMessage = "Password debe tener 6 caracteres!")]
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