namespace PrimeiraApi.ViewModel
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // IFormFile -> atraves dessa propiedade consigo acessar todos os atributos do arquivo, tipo, tamanho e arquivo por si próprio
        public IFormFile Photo { get; set; }
    }
}
