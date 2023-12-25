using System.ComponentModel.DataAnnotations.Schema;

namespace MyBiz.DTOs.Worker
{
    public class WorkerGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int PositionId { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
