using System;
using System.Collections.Generic;
using System.Linq;
using ProcSimProj.Business.Generics;

namespace ProcSimProj.Business.Responses
{
    public class ResponseBo
    {
        public ResponseBo()
        {
            Errors = new List<ErrorBo>();
        }
        public bool HasErrors
        {
            get { return Errors != null && Errors.Any(); }
        }

        private List<ErrorBo> Errors { get; set; }

        public void AddError(ErrorBo error)
        {
            Errors.Add(error);
        }

        public void AppendErrors(IEnumerable<ErrorBo> error)
        {
            Errors.AddRange(error);
        }

        public string GetErrorText()
        {
            return Errors.Aggregate(string.Empty, (current, error) => current + (error.Text + Environment.NewLine));
        }

    }

}
