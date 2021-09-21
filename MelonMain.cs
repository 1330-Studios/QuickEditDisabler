using System;
using System.Reflection;
using System.Runtime.InteropServices;

using MelonLoader;

using QuickEditDisable;

[assembly: AssemblyTitle(MelonMain.NAME)]
[assembly: AssemblyDescription("Disables QuickEdit on the MelonLoader console window.")]
[assembly: AssemblyCompany(MelonMain.AUTHOR)]
[assembly: AssemblyProduct(MelonMain.NAME)]
[assembly: AssemblyCopyright("Copyright © 1330 Studios LLC 2021")]
[assembly: AssemblyVersion(MelonMain.VERSION)]
[assembly: AssemblyFileVersion(MelonMain.VERSION)]

[assembly: MelonPlatformDomain(MelonPlatformDomainAttribute.CompatibleDomains.UNIVERSAL)]
[assembly: MelonInfo(typeof(MelonMain), MelonMain.NAME, MelonMain.VERSION, MelonMain.AUTHOR)]
[assembly: MelonGame(null, null)]
[assembly: MelonColor(ConsoleColor.DarkCyan)]

namespace QuickEditDisable {
    public sealed unsafe class MelonMain : MelonPlugin {
        public const string NAME = "QuickEdit Disabler";
        public const string VERSION = "1.0";
        public const string AUTHOR = "1330 Studios LLC";


        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int mode);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);

        public override void OnApplicationEarlyStart() {
            IntPtr handle = GetStdHandle(-10);
            GetConsoleMode(handle, out int mode);
            SetConsoleMode(handle, mode &= ~0x0040);
        }
    }
}
