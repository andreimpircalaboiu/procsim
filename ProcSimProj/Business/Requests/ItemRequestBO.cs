namespace ProcSimProj.Business.Requests
{
    public class ItemRequestBo<T> : RequestBo
    {
        public T Item { get; set; }
    }
}
