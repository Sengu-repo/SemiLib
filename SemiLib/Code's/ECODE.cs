using System.ComponentModel;

namespace Semi
{
    /// <summary>
    /// Error Code's
    /// </summary>
    public enum E_CODE : uint
    {
        // EAP
        //
        [Description("EAP server ipaddress invalid format")]
        EAP_SETUP_CONFIG_IP = 0x000003E8,
        [Description("EAP server Port invalid format")]
        EAP_SETUP_CONFIG_PORT = 0x000003E9,
        [Description("EAP Send/Recive Buffer Size")]
        EAP_SETUP_CONFIG_BUFFERSIZE = 0x000003EA,
        [Description("EAP Config init error")]
        EAP_SETUP_CONFIG_ERROR = 0x000003EB,

        // Socket
        //
        [Description("Socket Client EAP Config")]
        SOCKET_CONNECT_CONFIG = 0x0000044C,
        [Description("Scoket Client Null Reference")]
        SOCKET_CONNECT_NULL = 0x0000044D,
        [Description("Socket Connection Time Out")]
        SOCKET_CONNECT_TIMEOUT = 0x000044E,
        [Description("Socket Send Time Out")]
        SOCKET_SEND_TIMEOUT = 0x000044F,
        [Description("Socket Receive")]
        SOCKET_RECEIVE_MESSAGE = 0x0000450,
        [Description("Socket Disconnect")]
        SOCKET_DISCONNECT = 0x0000451
    }
}
