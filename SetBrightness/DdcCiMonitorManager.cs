﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SetBrightness
{
    // DDC/CI：https://docs.microsoft.com/en-us/windows/desktop/Monitor/monitor-configuration
    class DdcCiMonitorManager
    {
        [DllImport("User32.dll")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumProc lpfnEnum,
            IntPtr dwData);

        [return: MarshalAs(UnmanagedType.Bool)]
        private delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private static readonly List<DdcCiMonitor> DdcCiMonitors = new List<DdcCiMonitor>();

        /// <summary>
        /// 使用 ddc/ic 协议管理的显示器句柄
        /// </summary>
        /// <returns></returns>
        public static List<DdcCiMonitor> GetMonitorHandles()
        {
            if (!EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnumRroc, IntPtr.Zero))
            {
                Debug.WriteLine("EnumDisplayMonitors Fails");
            }

            return DdcCiMonitors;
        }

        private static bool MonitorEnumRroc(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
        {
            // https://docs.microsoft.com/en-us/windows/desktop/Monitor/using-the-high-level-monitor-configuration-functions#enumerating-physical-monitors
            // an HMONITOR handle can be associated with more than one physical monitor.
            // To configure the settings on a monitor, the application must get a unique handle to the physical monitor
            // by calling GetPhysicalMonitorsFromHMONITOR.

            // hMonitor 表示逻辑显示器句柄，一个 hMonitor 多个 physical displays：显示设置中的复制显示器
            var physicalHandles = GetPhysicalMonitorHandle(hMonitor);
            foreach (var handle in physicalHandles)
            {
                DdcCiMonitors.Add(new DdcCiMonitor(handle));
            }

            return true;
        }

        #region 获取物理显示器句柄

        [DllImport("dxva2.dll", EntryPoint = "GetNumberOfPhysicalMonitorsFromHMONITOR")]
        public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(
            IntPtr hMonitor, ref uint pdwNumberOfPhysicalMonitors);

        [DllImport("dxva2.dll", EntryPoint = "GetPhysicalMonitorsFromHMONITOR")]
        public static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint dwPhysicalMonitorArraySize,
            [Out] PhysicalMonitor[] pPhysicalMonitorArray);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct PhysicalMonitor
        {
            public IntPtr hPhysicalMonitor;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szPhysicalMonitorDescription;
        }

        public static List<IntPtr> GetPhysicalMonitorHandle(IntPtr hMonitor)
        {
            uint monitorCount = 0;
            GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, ref monitorCount);
            var physicalMonitors = new PhysicalMonitor[monitorCount];
            GetPhysicalMonitorsFromHMONITOR(hMonitor, monitorCount, physicalMonitors);

            return physicalMonitors.Select(physicalMonitor => physicalMonitor.hPhysicalMonitor).ToList();
        }

        #endregion
    }
}