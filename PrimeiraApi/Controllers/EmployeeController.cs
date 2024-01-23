using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PrimeiraApi.Aplication.ViewModel;
using PrimeiraApi.Domain.DTOs;
using PrimeiraApi.Domain.Model;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepoditory _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IActionResultTypeMapper _mapper;

        public EmployeeController(IEmployeeRepoditory employeeRepository, ILogger<EmployeeController> logger, IActionResultTypeMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {
            //1 passo para salvar a foto, pegar o caminho onde vou estar salvando meu arquivo
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);
            // 2 passso Classe Stream permite que eu salve meu arquivo dentro da memória e depois eu pego e coloco em alguma pasta do meu sistemas
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            //3 passo preciso pegar minha foto e adicionar dentro da minha stream
            employeeView.Photo.CopyTo(fileStream);
            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);
            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }
       
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantit)
        {
            _logger.Log(LogLevel.Error, "Teve um Erro");

            var employess = _employeeRepository.Get( pageNumber, pageQuantit);
            _logger.LogInformation("Teste");

            return Ok(employess);
        }

        [HttpGet]
        public IActionResult Search(int id)
        {
            var employess = _employeeRepository.Get(id);
            var employessDTOS = _mapper.Map<EmployeeDTO>(employess);
        
            return Ok(employess);
        }
    }
}
