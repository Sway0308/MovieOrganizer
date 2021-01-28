using Category.Standard.Handlers;
using Category.Standard.Interfaces;

namespace Category.Standard.Adaptors
{
    public class ExtensionAdaptor : IServiceAdaptor
    {
        private readonly ExtensionInDirHandler Handler = new ExtensionInDirHandler();
        public void Execute(string inputParam)
        {
            Handler.RecusiveSearch(inputParam);
        }
    }
}
