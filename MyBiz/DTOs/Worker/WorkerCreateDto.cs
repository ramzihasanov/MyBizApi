using FluentValidation;
using MyBiz.DTOs.Position;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBiz.DTOs.Worker
{
    public class WorkerCreateDto
    {
        public string Name { get; set; }
        public int PositionId { get; set; }
        public string About { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
    public class WorkerCreateDtoValidator : AbstractValidator<WorkerCreateDto>
    {
        public WorkerCreateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(30).WithMessage("its length dont must 30 ch");
            RuleFor(product => product.About)
                 .NotEmpty().WithMessage("name is required.")
                .MaximumLength(200).WithMessage("its length dont must 200 ch");
            RuleFor(product => product.TwitUrl)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.FaceUrl)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.InstaUrl)
               .NotEmpty().WithMessage("name is required.");
            RuleFor(product => product.LinkedinUrl)
               .NotEmpty().WithMessage("name is required.");
          
        }
    }
}
