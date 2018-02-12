using System.Collections.Generic;

namespace Resonate.BusinessService.Interface
{
    public interface IDataService
    {
        IDictionary<string, string> GetSchema();
        IEnumerable<dynamic> GetResultsByColumnFilter(string columnName, string filterValue);
    }
}