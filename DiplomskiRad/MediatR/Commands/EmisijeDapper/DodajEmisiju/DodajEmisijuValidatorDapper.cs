using FluentValidation;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.DodajEmisiju
{
    public class DodajEmisijuValidatorDapper : AbstractValidator<DodajEmisijuRequestDapper>
    {
        public DodajEmisijuValidatorDapper()
        {
            RuleFor(x => x.Naziv)
                .NotEmpty().WithMessage("Naziv TV postaje je obavezno polje.")
                .MaximumLength(50).WithMessage("Maksimalan broj znakova u nazivu TV postaje je 20.");
            RuleFor(x => x.Opis)
                .MaximumLength(200).WithMessage("Maksimalan broj znakova u nazivu TV postaje je 20.");
            RuleFor(x => x.TvPostajaId)
                .NotNull().WithMessage("Obavezno je odabrati TV postaju.");
            RuleFor(x => x.ZanrId)
                .NotNull().WithMessage("Obavezno je odabrati žanr emisije.");
        }
    }
}
