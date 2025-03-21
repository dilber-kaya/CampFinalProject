using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //data ve mesaj verir
        }

        public ErrorDataResult(T data) : base(data, false)
        {
            //sadece data verir
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
            //sadece mesaj verir
        }

        public ErrorDataResult() : base(default, false)
        {
            //hiçbir şey vermez
        }
    }
}
