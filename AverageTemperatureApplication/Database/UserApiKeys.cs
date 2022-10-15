using System.ComponentModel.DataAnnotations;

namespace AverageTemperatureApplication.Database
{
    public class UserApiKeys
    {
        [Key]
        public Guid UserId { get; set; }
        public int UserCount { get; set; }
    }
}
