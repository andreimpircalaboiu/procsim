using System.Collections.Generic;

namespace ProcSimProj.Business.Responses
{
    public class ListResponseBo<T> : ResponseBo
    {
        public IList<T> Result { get; set; }
    }
}
