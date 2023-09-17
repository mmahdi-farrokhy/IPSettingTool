using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace IPSettingTool.NetworkUtilities
{
    public static class NetworkConfiguration
    {
        public static List<string> LocalNetworkAdapaterNameList()
        {
            return NetworkInterface.GetAllNetworkInterfaces().
                            Select(netInterface => netInterface.Name).
                            ToList();
        }

        public static NetworkInterface LocalNetworkInterfaceNamedAs(string adapterName)
        {
            return NetworkInterface.GetAllNetworkInterfaces().
                            FirstOrDefault(netInterface => netInterface.OperationalStatus == OperationalStatus.Up &&
                            netInterface.Name.Equals(adapterName));
        }

        public static string GetLocalIPv4Address(string adapterName)
        {
            string localIPv4Address = "";
            NetworkInterface localNetworkInterfaceList = LocalNetworkInterfaceNamedAs(adapterName);
            if (localNetworkInterfaceList == null)
                throw new SystemNotConnectedToNetWorkException();

            foreach (var ipInfo in localNetworkInterfaceList.GetIPProperties().UnicastAddresses)
                if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                    localIPv4Address = ipInfo.Address.ToString();

            return localIPv4Address;
        }

        public static void SetNewStaticIPAddress(string adapterName, string newIpAddress)
        {
            try
            {
                foreach (ManagementObject adapterConfig in new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapterConfiguration").Get())
                    if ((bool)adapterConfig["IPEnabled"])
                        UpdateAdapterConfiguration(newIpAddress, adapterConfig);
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message, "Error while changing IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show($"IPv4 changed to {newIpAddress} for adapter \"{adapterName}\"", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void UpdateAdapterConfiguration(string newIpAddress, ManagementObject adapterConfig)
        {
            ManagementBaseObject newIP = adapterConfig.GetMethodParameters("EnableStatic");
            newIP["IPAddress"] = new string[] { newIpAddress };
            newIP["SubnetMask"] = new string[] { GetSystemSubnetMask() };

            ManagementBaseObject newGateway = adapterConfig.GetMethodParameters("SetGateways");
            newGateway["DefaultIPGateway"] = new string[] { newGateway.ToString() };
            newGateway["GatewayCostMetric"] = new int[] { 1 };

            //EnableDHCPForAdapter(adapterConfig);

            adapterConfig.InvokeMethod("EnableStatic", newIP, null);
            adapterConfig.InvokeMethod("SetGateways", newGateway, null);
        }

        private static string GetSystemSubnetMask()
        {
            string subnetMask = null;

            try
            {
                foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    foreach (UnicastIPAddressInformation ipInfo in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            subnetMask = ipInfo.IPv4Mask.ToString();
                            break;
                        }
                    }

                    if (subnetMask != null)
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return subnetMask;
        }
    }
}
