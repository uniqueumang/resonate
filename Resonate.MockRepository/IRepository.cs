using System.Collections.Generic;

namespace Resonate.MockRepository
{
    public interface IRepository
    {
        dynamic GetFirst();

        IEnumerable<dynamic> GetResultsByFilter(string column, string filtervalue);
    }
}