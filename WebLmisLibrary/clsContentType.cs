using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;
using System.IO;


namespace NIC.WebLMISLibrary
{
    public class clsContentType
    {
        clsCommonFunc func = new clsCommonFunc();
        public int MimeSampleSize = 256;
        public string DefaultMimeType = "application/pdf";

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        public extern static uint FindMimeFromData(
            uint pBC,
            [MarshalAs(UnmanagedType.LPStr)] string pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            uint cbSize,
            [MarshalAs(UnmanagedType.LPStr)] string pwzMimeProposed,
            uint dwMimeFlags,
            out uint ppwzMimeOut,
            uint dwReserverd
        );

        public string GetMimeFromBytes(byte[] data)
        {
            try
            {
                uint mimeType;
                FindMimeFromData(0, null, data, (uint)MimeSampleSize, null, 0, out mimeType, 0);
                IntPtr mimePointer = new IntPtr(mimeType);
                string mime = Marshal.PtrToStringUni(mimePointer);
                Marshal.FreeCoTaskMem(mimePointer);
                return mime;
            }
            catch
            {
                return DefaultMimeType;
            }
        }
    }
}
