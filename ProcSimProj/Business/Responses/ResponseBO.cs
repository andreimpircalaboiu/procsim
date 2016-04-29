using System;
using System.Collections.Generic;
using System.Linq;
using ProcSimProj.Business.BOs;

namespace ProcSimProj.Business.Responses
{
    public class ResponseBo
    {
        public ResponseBo()
        {
            Errors = new List<ErrorBo>();
        }
        public bool HasErrors => Errors != null && Errors.Any();
        private List<ErrorBo> Errors { get; }

        public void AddError(ErrorBo error)
        {
            Errors.Add(error);
        }

        public void AppendErrors(IEnumerable<ErrorBo> error)
        {
            Errors.AddRange(error);
        }

    }

}
