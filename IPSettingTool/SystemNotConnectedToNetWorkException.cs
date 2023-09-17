using System.Runtime.Serialization;

namespace IPSettingTool
{
    [Serializable]
    internal class SystemNotConnectedToNetWorkException : Exception
    {
        public SystemNotConnectedToNetWorkException()
        {
        }
    }
}