﻿using Webapidotnet.Domain.DTOs;

namespace Webapidotnet.Domain.Model.EmployeeAggregate
{
    public interface IEmployeeRepoditory
    {
        void Add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);

        Employee? Get(int id);
    }
}
