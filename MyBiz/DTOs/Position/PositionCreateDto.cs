using FluentValidation;

namespace MyBiz.DTOs.Position
{
    public class PositionCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PositionCreateDtoValidator : AbstractValidator<PositionCreateDto>
    {
        public PositionCreateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(30).WithMessage("its length dont must 30 ch");
        }
    }
}
    
