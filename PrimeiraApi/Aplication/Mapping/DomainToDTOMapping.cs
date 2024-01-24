using PrimeiraApi.Domain.Model.EmployeeAggregate;

namespace PrimeiraApi.Aplication.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        } 
    }
}
