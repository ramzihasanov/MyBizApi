using System.ComponentModel.DataAnnotations.Schema;

namespace MyBiz.Entities
{
    public class Worker:BaseEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }    
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string ImageUrl { get; set; }


    }
}
