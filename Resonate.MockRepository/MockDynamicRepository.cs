using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Resonate.MockRepository
{
    public class MockDynamicRepository : IRepository
    {
        public dynamic GetFirst()
        {
            dynamic returnObject = new ExpandoObject();
            returnObject.FirstName = "Umang";
            returnObject.LastName = "Parikh";
            returnObject.DoB = new DateTime(1996, 04, 05);
            returnObject.Id = 10;
            return returnObject;
        }

        public IEnumerable<dynamic> GetResultsByFilter(string column, string filtervalue)
        {
            throw new NotImplementedException();
        }
    }
}