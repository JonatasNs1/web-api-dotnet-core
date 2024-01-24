using WebApi.Domain.DTOs;
using WebApi.Domain.Model.EmployeeAggregate;

namespace WebApi.Infraestrutura.Repositories
{
    public class EmployeeRepository : IEmployeeRepoditory
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log ou manipulação de exceções aqui
                throw new Exception("Erro ao adicionar funcionário ao banco de dados.", ex);
            }
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity)
                .Select(b =>
                new EmployeeDTO() {
                    Id = b.id,
                    NameEmploye = b.name,
                    Photo = b.photo
                })
                .ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
