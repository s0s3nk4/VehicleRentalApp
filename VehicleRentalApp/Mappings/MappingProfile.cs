using AutoMapper;
using VehicleRentalApp.Models;
using VehicleRentalApp.ViewModels;

namespace VehicleRentalApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentItemViewModel>()
                .ForMember(dest => dest.EquipmentType, opt => opt.MapFrom(src => src.EquipmentType != null ? src.EquipmentType.Name : ""))
                .ForMember(dest => dest.RentalPoint, opt => opt.MapFrom(src => src.RentalPoint != null ? src.RentalPoint.Address : ""));

            CreateMap<EquipmentItemViewModel, Equipment>()
                .ForMember(dest => dest.EquipmentType, opt => opt.Ignore());

            CreateMap<Equipment, EquipmentDetailViewModel>()
                .ForMember(dest => dest.EquipmentType, opt => opt.MapFrom(src => src.EquipmentType != null ? src.EquipmentType.Name : ""))
                .ForMember(dest => dest.RentalPoint, opt => opt.MapFrom(src => src.RentalPoint != null ? src.RentalPoint.Address : ""));

            CreateMap<EquipmentDetailViewModel, Equipment>()
                .ForMember(dest => dest.EquipmentType, opt => opt.Ignore());

            CreateMap<EquipmentType, EquipmentTypeViewModel>().ReverseMap();

            CreateMap<RentalPoint, RentalPointViewModel>().ReverseMap();
        }
    }
}
