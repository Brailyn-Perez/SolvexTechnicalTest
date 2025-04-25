using System.Net.Sockets;
using System.Net;

namespace SolvexTechnicalTest.Infraestructe.Identity.Helpers
{
    public class IpHelper
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            return string.Empty;
        }
    }
}
