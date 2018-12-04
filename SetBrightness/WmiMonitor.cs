﻿using System.Management;
using System.Runtime.InteropServices;

namespace SetBrightness
{
    internal class WmiMonitor : Monitor
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WmiMonitorBrightnessClass
        {
            public bool Active;
            public byte CurrentBrightness;
            public string InstanceName;
            public byte[] Level;
            public uint Levels;
        }

        private readonly string _instanceId;

        private WmiMonitorBrightnessClass _wmiMonitorBrightness;

        public WmiMonitor(string instanceId)
        {
            _instanceId = instanceId;
            SupportContrast = false;
        }

        public override void SetBrightness(int brightness)
        {
            using (var searcher = GetBrightnessSearcher("WmiMonitorBrightnessMethods"))
            using (var instances = searcher.Get())
            {
                foreach (var instance in instances)
                {
                    if (!RightDevice(instance))
                    {
                        continue;
                    }

                    ((ManagementObject) instance).InvokeMethod("WmiSetBrightness", new object[]
                    {
                        (uint) 2, (byte) brightness
                    });
                }
            }
        }

        private ManagementObjectSearcher GetBrightnessSearcher(string queryStr)
        {
            var scope = new ManagementScope("root\\WMI");
            var query = new SelectQuery(queryStr);

            return new ManagementObjectSearcher(scope, query);
        }

        public override int GetBrightness()
        {
            _wmiMonitorBrightness = GetBrightnessInfo();
            return _wmiMonitorBrightness.CurrentBrightness;
        }

        private WmiMonitorBrightnessClass GetBrightnessInfo()
        {
            using (var searcher = GetBrightnessSearcher("WmiMonitorBrightness"))
            using (var instances = searcher.Get())
            {
                foreach (var instance in instances)
                {
                    if (!RightDevice(instance))
                    {
                        continue;
                    }

                    _wmiMonitorBrightness.Active = (bool) instance["Active"];
                    _wmiMonitorBrightness.CurrentBrightness = (byte) instance["CurrentBrightness"];
                    _wmiMonitorBrightness.InstanceName = (string) instance["InstanceName"];
                    _wmiMonitorBrightness.Level = (byte[]) instance["Level"];
                    _wmiMonitorBrightness.Levels = (uint) instance["Levels"];
                }
            }

            return _wmiMonitorBrightness;
        }

        public override void SetContrast(int contrast)
        {
        }

        public override int GetContrast()
        {
            return -1;
        }

        private bool RightDevice(ManagementBaseObject instance)
        {
            // InstanceName         DISPLAY\SDC4C48\4&2e490a7&0&UID265988_0
            // deviceInstanceId     DISPLAY\SDC4C48\4&2e490a7&0&UID265988
            string instanceName = (string) instance["InstanceName"];
            return _instanceId.Contains(instanceName);
        }
    }
}