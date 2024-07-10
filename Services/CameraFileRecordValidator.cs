using System.Text.RegularExpressions;
using FluentValidation;
using Services.DataAccess;

namespace Services
{
    public class CameraFileRecordValidator : AbstractValidator<CameraFileRecord>
    {
        public CameraFileRecordValidator()
        {
            RuleFor(p => p.Camera)
                .NotEmpty()
                .Must(p =>
                {
                    var pattern = @"^UTR-CM-(\d{3})\s[\w\s]+$";
                    var match = Regex.Match(p, pattern);
                    var value = match.Groups[1].Value;
                    return match.Success && int.TryParse(value, out _);
                });

            RuleFor(p => p.Latitude)
                .NotEmpty()
                .Must(p => decimal.TryParse(p, out _));

            RuleFor(p => p.Longitude)
                .NotEmpty()
                .Must(p => decimal.TryParse(p, out _));
        }
    }
}
