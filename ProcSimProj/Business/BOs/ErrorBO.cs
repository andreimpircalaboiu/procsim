using System;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.BOs
{
    public class ErrorBo
    {
        public object Object { get; set; }
        public Type ObjectType { get; set; }
        public ErrorType ErrorType { get; set; }
        public string Text { get; set; }
    }
}
