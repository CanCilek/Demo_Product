using System;
using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface ICustomerService : IGenericService<Customer>
	{
		List<Customer> GetCustomersListWithJob();
	}
}

