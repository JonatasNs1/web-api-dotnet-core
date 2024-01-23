﻿using PrimeiraApi.Domain.DTOs;

namespace PrimeiraApi.Domain.Model
{
    public interface IEmployeeRepoditory
    {
        void Add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);

        Employee? Get(int id);
    }
}
