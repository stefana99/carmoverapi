using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMoverApi.Models
{
    public class User
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FaceBookUserId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}