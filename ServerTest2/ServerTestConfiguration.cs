using System.Runtime.Serialization;

namespace ServerTest2
{
    // configuration of data access node manager.
    [DataContract(Namespace = Namespaces.NodeTest)]
    internal class ServerTestConfiguration
    {
        // The default constructor.
        public ServerTestConfiguration()
        {
            Initialize();
        }
        // Initializes the object during deserialization.
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
        // Sets private members to default values.
        private void Initialize()
        {
        }
    }
}