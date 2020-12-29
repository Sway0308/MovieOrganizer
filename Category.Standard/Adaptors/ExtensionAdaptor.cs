using Category.Standard.Handlers;
using Category.Standard.Interfaces;

namespace Category.Standard.Adaptors
{
    public class ExtensionAdaptor : IServiceAdaptor
    {
        private readonly ExtensionHandler Handler = new ExtensionHandler();
        public void Execute(string inputParam)
        {
            Handler.RecusiveSearch(inputParam);
        }
    }
}
