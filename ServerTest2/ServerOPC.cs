using System.Collections.Generic;
using Opc.Ua;
using Opc.Ua.Server;

namespace ServerTest2
{
    public partial class ServerOPC : StandardServer
    {
        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            Utils.Trace("Creating the Node Managers.");
            List<INodeManager> nodeManagers = new List<INodeManager>();
             // create the custom node managers.
            nodeManagers.Add(new ServerNodeManager(server, configuration));
            // create master node manager.
            return new MasterNodeManager(server, configuration, null, nodeManagers.ToArray());
        }

        //setting the sever properties
        protected override ServerProperties LoadServerProperties()
        {
            ServerProperties properties = new ServerProperties();
            properties.ManufacturerName = "KlingelnBerg GMBH";
            properties.ProductName = "Server Test";
            properties.ProductUri = "xyz.com";
            properties.SoftwareVersion = Utils.GetAssemblySoftwareVersion();
            properties.BuildNumber = Utils.GetAssemblyBuildNumber();
            properties.BuildDate = Utils.GetAssemblyTimestamp();

            // TBD - All applications have software certificates that need to added to the properties.

            return properties;
        }

        //Creating Resource manager for the server.
        protected override ResourceManager CreateResourceManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            ResourceManager resourceManager = new ResourceManager(server, configuration);
            System.Reflection.FieldInfo[] fields = typeof(StatusCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            foreach (System.Reflection.FieldInfo field in fields)
            {
                uint? id = field.GetValue(typeof(StatusCodes)) as uint?;
                if (id != null)
                {
                    resourceManager.Add(id.Value, "en-US", field.Name);
                }
            }
            return resourceManager;
        }

        // Initializes the server before it starts up.
        /// <remarks>
        /// This method is called before any startup processing occurs. The sub-class may update the 
        /// configuration object or do any other application specific startup tasks.
        /// </remarks>
        protected override void OnServerStarting(ApplicationConfiguration configuration)
        {
            Utils.Trace("The server is starting.");
            base.OnServerStarting(configuration);
        }
        
        // Called after the server has been started.
        protected override void OnServerStarted(IServerInternal server)
        {
            base.OnServerStarted(server);
        }
    }
}
