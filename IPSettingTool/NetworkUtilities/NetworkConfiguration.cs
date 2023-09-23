using System.Diagnostics;
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

        public static string GetGatewayAddress(string adapterName)
        {
            NetworkInterface networkInterfaces = LocalNetworkInterfaceNamedAs(adapterName);
            GatewayIPAddressInformationCollection gatewayAddresses = networkInterfaces.GetIPProperties().GatewayAddresses;

            if (gatewayAddresses.Count > 0)
            {
                return gatewayAddresses[0].Address.ToString();
            }
            else
            {
                return "";
            }
        }

        public static bool SetNewGatewayAddress(string adapterName, string newGatewayAddress)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = $"interface ip set address \"{adapterName}\" gateway={newGatewayAddress} gwmetric=0";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Check if the operation was successful
                MessageBox.Show("New gateway set successfully");
                return output.Contains("Ok.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static void SetIP(string nicName, string IpAddresses, string Gateway)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if ((bool)(mo["IPEnabled"]))
                {
                    var desc = mo["Caption"];
                    if (desc.Equals("[00000008] Realtek PCIe GBE Family Controller"))
                    {
                        ManagementBaseObject newIP = mo.GetMethodParameters("EnableStatic");
                        ManagementBaseObject newGate = mo.GetMethodParameters("SetGateways");
                        ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");

                        newGate["DefaultIPGateway"] = new string[] { Gateway };
                        newGate["GatewayCostMetric"] = new int[] { 1 };

                        newIP["IPAddress"] = IpAddresses.Split(',');

                        ManagementBaseObject setIP = mo.InvokeMethod(
                          "EnableStatic", newIP, null);
                        ManagementBaseObject setGateways = mo.InvokeMethod(
                          "SetGateways", newGate, null);
                        ManagementBaseObject setDNS = mo.InvokeMethod(
                          "SetDNSServerSearchOrder", newDNS, null);

                        break;
                    }
                }
            }
        }

        public static void setGateway(string gateway)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setGateway;
                        ManagementBaseObject newGateway =
                            objMO.GetMethodParameters("SetGateways");

                        newGateway["DefaultIPGateway"] = new string[] { gateway };
                        newGateway["GatewayCostMetric"] = new int[] { 1 };

                        setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
