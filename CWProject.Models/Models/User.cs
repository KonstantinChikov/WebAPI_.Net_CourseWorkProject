using System.Text.Json.Serialization;

namespace CWProject.Models.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }

        //[Required]
        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public ICollection<Villas> Villas { get; set; }
    }
}
