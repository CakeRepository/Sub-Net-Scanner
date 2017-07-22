using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Host_Subnet_Scan
{
    class NetworkManagement
    {
        /// <summary>
        /// Set's a new IP Address and it's Submask of the local machine
        /// </summary>
        /// <param name="ipAddress">The IP Address</param>
        /// <param name="subnetMask">The Submask IP Address</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetIp(string ipAddress, string subnetMask)
        {
            ManagementObjectCollection objMOC;
            using (var objMc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                objMOC = objMc.GetInstances();
            }

            foreach (var o in objMOC)
            {
                var objMo = (ManagementObject) o;
                if (!(bool) objMo["IPEnabled"]) continue;
                try
                {
                    var newIp =
                        objMo.GetMethodParameters("EnableStatic");

                    newIp["IPAddress"] = new string[] { ipAddress };
                    newIp["SubnetMask"] = new string[] { subnetMask };

                    objMo.InvokeMethod("EnableStatic", newIp, null);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void SetDhcp()
        {
            var objMc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var objMoc = objMc.GetInstances();

            foreach (ManagementObject objMo in objMoc)
            {
                if (!(bool) objMo["IPEnabled"]) continue;
                try
                {
                    var newIp = objMo.GetMethodParameters("EnableStatic");
                        

                    objMo.InvokeMethod("EnableDHCP", null, null);
                }
                catch (Exception)
                {
                        
                }
            }
        }
        /// <summary>
        /// Set's a new Gateway address of the local machine
        /// </summary>
        /// <param name="gateway">The Gateway IP Address</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetGateway(string gateway)
        {
            var objMc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var objMOC = objMc.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (!(bool) objMO["IPEnabled"]) continue;
                try
                {
                    var newGateway =
                        objMO.GetMethodParameters("SetGateways");

                    newGateway["DefaultIPGateway"] = new string[] { gateway };
                    newGateway["GatewayCostMetric"] = new int[] { 1 };

                    objMO.InvokeMethod("SetGateways", newGateway, options: null);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Set's the DNS Server of the local machine
        /// </summary>
        /// <param name="nic">NIC address</param>
        /// <param name="dns">DNS server address</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetDns(string nic, string dns)
        {
            var objMc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var objMoc = objMc.GetInstances();

            foreach (var o in objMoc)
            {
                var objMo = (ManagementObject) o;
                Console.WriteLine(objMo["Caption"].ToString());
                if (!(bool) objMo["IPEnabled"]) continue;
                Console.WriteLine(objMo.ToString());
                // if you are using the System.Net.NetworkInformation.NetworkInterface you'll need to change this line to if (objMO["Caption"].ToString().Contains(NIC)) and pass in the Description property instead of the name 
                if (!objMo["Caption"].Equals(nic)) continue;
                try
                {
                    using (var newDns = objMo.GetMethodParameters("SetDNSServerSearchOrder"))
                    {
                        newDns["DNSServerSearchOrder"] = dns.Split(',');
                        objMo.InvokeMethod("SetDNSServerSearchOrder", newDns, null);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }
        public string GetDefaultGateway()
        {
            var defaultGateway =
            from nics in NetworkInterface.GetAllNetworkInterfaces()
            from props in nics.GetIPProperties().GatewayAddresses
            where nics.OperationalStatus == OperationalStatus.Up
            select props.Address.ToString();
            var enumerable = defaultGateway as string[] ?? defaultGateway.ToArray();
            return !enumerable.Any() ? " " : enumerable.First();
        }
        public void ExecuteCommand(string command)
        {
            var process = new System.Diagnostics.Process();
            var startInfo =
                new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C " + command
                };
            process.StartInfo = startInfo;
            process.Start();
            
        }

        /// <summary>
        /// Call this method when needing to get the local IPV4 address using the adapter type youre looking for
        /// </summary>
        /// <param>
        ///     <name>Network adapter</name>
        /// </param>
        /// <param name="type"></param>
        /// <returns>Current IPV4 Address</returns>
        public string GetLocalIPv4(NetworkInterfaceType type)
        {
            var output = "";
            foreach (var item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType != type || item.OperationalStatus != OperationalStatus.Up) continue;
                foreach (var ip in item.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        output = ip.Address.ToString();
                    }
                }
            }
            return output;
        }

        public int FindLast(string ip)
        {
            var count = 0;
            var lastDot = 155;
            const char lookFor = '.';
            
            for (var i = 0; i < ip.Length; i++)
            {
                if (ip[i].Equals(lookFor))
                {
                    count++;
                }
                if (count == 3)
                {
                    lastDot = i;
                }
            }
            return lastDot;
        }
    }
}
