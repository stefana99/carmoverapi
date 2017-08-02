using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMoverApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FaceBookUserId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string RecipientId { get; set; }
        public string ServiceUrl { get; set; }
        public string ChannelId { get; set; }
        public string ConversationId { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}