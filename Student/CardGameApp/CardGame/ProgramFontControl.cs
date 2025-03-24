using System;
using System.Runtime.InteropServices;

namespace CardGameApp
{
    class ProgramFontControl
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CONSOLE_FONT_INFO_EX
        {
            public uint cbSize;
            public uint nFont;
            public short dwFontSizeX;
            public short dwFontSizeY;
            public int FontFamily;
            public int FontWeight;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string FaceName;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        private const int STD_OUTPUT_HANDLE = -11;

        public static void FontControl(string Font)
        {
            IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);

            CONSOLE_FONT_INFO_EX fontInfo = new CONSOLE_FONT_INFO_EX();
            fontInfo.cbSize = (uint)Marshal.SizeOf(fontInfo);
            fontInfo.FaceName = Font; // Set your desired font name here
            fontInfo.dwFontSizeX = 14; // Font width
            fontInfo.dwFontSizeY = 24; // Font height
            fontInfo.FontFamily = 54; // FF_MODERN | FIXED_PITCH
            fontInfo.FontWeight = 400; // Normal weight

            bool result = SetCurrentConsoleFontEx(handle, false, ref fontInfo);

            if (result)
            {
                Console.WriteLine("Console font changed successfully!");
            }
            else
            {
                Console.WriteLine("Failed to change console font.");
            }
        }
    }
}