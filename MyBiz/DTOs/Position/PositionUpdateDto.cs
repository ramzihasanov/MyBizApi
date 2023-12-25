using FluentValidation;

namespace MyBiz.DTOs.Position
{
    public class PositionUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PositionUpdateDtoValidator : AbstractValidator<PositionUpdateDto>
    {
        public PositionUpdateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(30).WithMessage("its length dont must 30 ch");
        }
    }
}