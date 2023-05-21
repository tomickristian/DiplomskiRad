using AutoMapper;
using DiplomskiRad.Models;
using DiplomskiRad.MediatR.Commands.EmisijeDapper.DodajEmisiju;
using DiplomskiRad.MediatR.Commands.EmisijeEFC.DodajEmisiju;
using DiplomskiRad.MediatR.Commands.EmisijeDapper;
using DiplomskiRad.MediatR.Commands.EmisijeEFC.UrediEmisiju;
using DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisije;
using DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisijuPoId;
using DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisije;
using DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisijuPoId;

namespace DiplomskiRad.Mappers
{
    public class EmisijeMapper : Profile
    {
        public EmisijeMapper()
        {
            CreateMap<Emisija, DohvatiEmisijeResponseEFC>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.DatumIvrijemePrikazivanja, opt => opt.MapFrom(src => src.DatumIvrijemePrikazivanja));

            CreateMap<Emisija, DohvatiEmisijeResponseDapper>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.DatumIvrijemePrikazivanja, opt => opt.MapFrom(src => src.DatumIvrijemePrikazivanja));

            CreateMap<Emisija, DohvatiEmisijuPoIdResponseEFC>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.DatumIvrijemePrikazivanja, opt => opt.MapFrom(src => src.DatumIvrijemePrikazivanja))
                .ForMember(dest => dest.TvPostajaId, opt => opt.MapFrom(src => src.TvPostajaId))
                .ForMember(dest => dest.ZanrId, opt => opt.MapFrom(src => src.ZanrId))
                .ForMember(dest => dest.TvPostajaNaziv, opt => opt.MapFrom(src => src.TvPostaja.Naziv))
                .ForMember(dest => dest.ZanrNaziv, opt => opt.MapFrom(src => src.Zanr.Naziv));

            CreateMap<Emisija, DohvatiEmisijuPoIdResponseDapper>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.DatumIvrijemePrikazivanja, opt => opt.MapFrom(src => src.DatumIvrijemePrikazivanja))
                .ForMember(dest => dest.TvPostajaId, opt => opt.MapFrom(src => src.TvPostajaId))
                .ForMember(dest => dest.ZanrId, opt => opt.MapFrom(src => src.ZanrId))
                .ForMember(dest => dest.TvPostajaNaziv, opt => opt.MapFrom(src => src.TvPostaja.Naziv))
                .ForMember(dest => dest.ZanrNaziv, opt => opt.MapFrom(src => src.Zanr.Naziv));

            CreateMap<DodajEmisijuRequestEFC, Emisija>()
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.DatumIvrijemePrikazivanja, opt => opt.MapFrom(src => src.DatumIvrijemePrikazivanja))
                .ForMember(dest => dest.TvPostajaId, opt => opt.MapFrom(src => src.TvPostajaId))
                .ForMember(dest => dest.ZanrId, opt => opt.MapFrom(src => src.ZanrId));

            CreateMap<UrediEmisijuRequestEFC, Emisija>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
                .ForMember(dest => dest.DatumIvrijemePrikazivanja, opt => opt.MapFrom(src => src.DatumIvrijemePrikazivanja))
                .ForMember(dest => dest.TvPostajaId, opt => opt.MapFrom(src => src.TvPostajaId))
                .ForMember(dest => dest.ZanrId, opt => opt.MapFrom(src => src.ZanrId));
        }
    }
}
