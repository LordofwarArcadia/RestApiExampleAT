using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExampleAutomatedTests.Helper
{
    public interface IParameter : ISimpleParameter
    {
        List<IPart> Part { get; set; }
    }

    public interface ISimpleParameter
    {
        string Name { get; set; }
    }

    public interface IPart { }
    public interface IItem
    {
        string ResourceType { get; set; }
        List<ISimpleParameter> Parameter { get; set; }
    }
}
