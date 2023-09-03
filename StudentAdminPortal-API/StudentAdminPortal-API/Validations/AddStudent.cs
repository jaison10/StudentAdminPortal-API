using FluentValidation;
using StudentAdminPortal_API.DomainModels;
using StudentAdminPortal_API.Repositories;

namespace StudentAdminPortal_API.Validations
{
    public class AddStudent : AbstractValidator<NewStudentData>
    {
        public AddStudent(IStudentRepository studentRepository)
        {
            RuleFor(x => x.firstname).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).NotEmpty().GreaterThanOrEqualTo(1000000000);
            RuleFor(x => x.DOB).NotEmpty();
            RuleFor(x => x.GenderID).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetAllGenders().Result.ToList().FirstOrDefault(x => x.Id == id);
                if (gender != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Please select a valid gender.");
        }
    }
}
