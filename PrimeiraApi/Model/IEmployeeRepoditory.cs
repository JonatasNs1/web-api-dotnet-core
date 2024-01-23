namespace PrimeiraApi.Model
{
    public interface IEmployeeRepoditory
    {
        void Add(Employee employee);
        List<Employee> Get(int pageNumber, int pageQuantity);

        Employee? Get(int id);
    }
}
