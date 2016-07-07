using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AlarmSystem.Entities;

namespace AlarmSystem.DAL
{
    public enum ManagementPackageType
    {
        BuzzOn,
        BuzzOff
    }

    public static class Packer
    {
        private static uint ToUInt32Network(byte[] buffer, int startIndex)
            => (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, startIndex));

        public static Report ParseReport(IList<byte> buffer)
        {
            int startIndex;
            for (startIndex = 0; startIndex < buffer.Count; startIndex++)
                if (buffer[startIndex] == 0x5A)
                    break;
            if (buffer.Count - startIndex < 12)
                return null;

            byte tmp = 0;
            for (var i = startIndex; i < startIndex + 11; i++)
                tmp = (byte)(tmp ^ buffer[i]);
            if (tmp != buffer[startIndex + 11])
                return null;

            var rawBuffer = buffer.ToArray();

            var lacc = ToUInt32Network(rawBuffer, startIndex + 2);
            var acc = Math.Sqrt(lacc);

            var ldist = ToUInt32Network(rawBuffer, startIndex + 6);
            var dist = ldist * 40.0 * 170 / 1000000;

            return
                new Report
                    {
                        Illuminance = buffer[startIndex + 1],
                        Acceleration = acc,
                        Distance = dist,
                        IsBuzzerOn = (buffer[startIndex + 10] & 0x01) == 0x01,
                        TimeStamp = DateTime.Now,
                        RawBytes = rawBuffer
                    };
        }

        // ReSharper disable once UnusedParameter.Global
        public static byte[] GenerateManagementPackage(ManagementPackageType type, params object[] param)
        {
            switch (type)
            {
                case ManagementPackageType.BuzzOn:
                    return new byte[] { 0x88 };
                case ManagementPackageType.BuzzOff:
                    return new byte[] { 0x99 };
                default:
                    throw new ArgumentException("包类型无效", nameof(type));
            }
        }
    }
}
