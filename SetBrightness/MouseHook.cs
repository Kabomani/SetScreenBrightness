﻿using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SetBrightness
{
    // 来自：https://github.com/rvknth043/Global-Low-Level-Key-Board-And-Mouse-Hook

    /// <summary>
    /// Class for intercepting low level Windows mouse hooks.
    /// </summary>
    class MouseHook
    {
        /// <summary>
        /// Internal callback processing function
        /// </summary>
        private delegate int MouseHookHandler(int nCode, int wParam, IntPtr lParam);

        /// <summary>
        /// Function to be called when defined even occurs
        /// </summary>
        /// <param name="mouseStruct">MSLLHOOKSTRUCT mouse structure</param>
        public delegate void MouseHookCallback(Msllhookstruct mouseStruct, out bool goOn);

        public event MouseHookCallback MouseWheel;

        private IntPtr _hookId = IntPtr.Zero;

        public void Install()
        {
            _hookId = SetHook(HookFunc);
        }

        /// <summary>
        /// Remove low level mouse hook
        /// </summary>
        public void Uninstall()
        {
            if (_hookId == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(_hookId);
            _hookId = IntPtr.Zero;
        }

        /// <summary>
        /// Destructor. Unhook current hook
        /// </summary>
        ~MouseHook()
        {
            Uninstall();
        }

        /// <summary>
        /// Sets hook and assigns its ID for tracking
        /// </summary>
        /// <param name="proc">Internal callback function</param>
        /// <returns>Hook ID</returns>
        private IntPtr SetHook(MouseHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(WhMouseLl, proc, GetModuleHandle(module.ModuleName), 0);
        }

        /// <summary>
        /// Callback function
        /// </summary>
        private int HookFunc(int nCode, int wParam, IntPtr lParam)
        {
            // parse system messages
            if (nCode >= 0)
            {
                if (MouseMessages.WmMousewheel == (MouseMessages) wParam)
                {
                    Msllhookstruct msllhookstruct = (Msllhookstruct) Marshal.PtrToStructure(lParam, typeof(Msllhookstruct));
                    if (MouseWheel != null)
                    {
                        bool goOn;
                        MouseWheel(msllhookstruct, out goOn);
                        if (!goOn)
                        {
                            return 1;
                        }
                    }
                }
            }

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        #region WinAPI

        private const int WhMouseLl = 14;

        private enum MouseMessages
        {
            WmMousewheel = 0x020A
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Msllhookstruct
        {
            public Point pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int CallNextHookEx(IntPtr hhk, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}