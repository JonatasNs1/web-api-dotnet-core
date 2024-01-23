using PrimeiraApi.Model;

namespace PrimeiraApi.Infraestrutura
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

        public List<Employee> Get(int pageNumber, int pageQuantity)
        {
           return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
