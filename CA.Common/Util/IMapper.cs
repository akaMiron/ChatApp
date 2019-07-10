using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Common.Util
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
