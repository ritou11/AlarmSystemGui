using System;
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
        public static Report ParseReport(byte[] buffer, out int lastPackageTail)
        {
            lastPackageTail = -1;
            int startIndex;
            for (startIndex = 0; startIndex < buffer.Length; startIndex++)
                if (buffer[startIndex] == 0x5A)
                    break;
            if (buffer.Length - startIndex < 8)
                return null;
            byte tmp = 0;
            for (var i = startIndex + 1; i < startIndex + 7; i++)
                tmp = (byte)(tmp ^ buffer[i]);
            if (tmp != buffer[startIndex + 7])
                return null;

            lastPackageTail = startIndex + 7;

            var ldist = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, startIndex + 1));
            var dist = ldist * 40.0 * 170 / 1000000;

            return
                new Report
                    {
                        Distance = dist,
                        Acceleration = 1.0,
                        Illuminance = buffer[startIndex + 5],
                        IsShaking = (buffer[startIndex + 6] & 0x01) == 0x01,
                        TimeStamp = DateTime.Now,
                        IsBuzzerOn = (buffer[startIndex + 6] & 0x02) == 0x02,
                        RawBytes = buffer
                    };
        }

        public static byte[] GenerateManagementPackage(ManagementPackageType type, params object[] param)
        {
            switch (type)
            {
                case ManagementPackageType.BuzzOn:
                    return new byte[] { 0x88 };
                case ManagementPackageType.BuzzOff:
                    return new byte[] { 0x99 };
                default:
                    throw new ArgumentException("包类型无效", "type");
            }
        }
    }
}
