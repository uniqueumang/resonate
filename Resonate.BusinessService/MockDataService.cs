using System;
using System.Collections.Generic;
using System.Dynamic;
using Resonate.BusinessService.Interface;

namespace Resonate.MockBusinessService
{
    public class MockDataService : IDataService
    {
        public IDictionary<string, string> GetSchema()
        {
            return new Dictionary<string, string> {{"Name", "nvarchar(255)"}, {"DoB", "datetime2"}, {"Id", "int"}};
        }

        public IEnumerable<dynamic> GetResultsByColumnFilter(string columnName, string filterValue)
        {
            if (string.IsNullOrWhiteSpace(filterValue) && !string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentNullException(nameof(filterValue),
                    $"If {nameof(columnName)} is present {nameof(filterValue)} is also required");
            return new dynamic[]
            {
                CreateDynamicObject("Umang", DateTime.Today.AddYears(-18), 123),
                CreateDynamicObject("Rebecca", DateTime.Today.AddYears(-78), 124)
            };
        }

        private ExpandoObject CreateDynamicObject(string name, DateTime DoB, int Id)
        {
            dynamic obj = new ExpandoObject();
            obj.Name = name;
            obj.DoB = DoB;
            obj.Id = Id;
            return obj;
        }
    }
}