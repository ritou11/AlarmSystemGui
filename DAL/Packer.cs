using System;
using AlarmSystem.Entities;
using System.Collections;
using System.Net;

namespace AlarmSystem.DAL
{
    public enum ManagementPackageType
    {
        BuzzOn,
        BuzzOff
    }

    public static class Packer
    {
        public static Report ParseReport(byte[] buffer)
        {
            byte tmp = 0;
            for (var i = 1; i < 7; i++)
                tmp = (byte)(tmp ^ buffer[i]);
            if (tmp != buffer[7])
                return null;
            var ldist = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 1));
            var dist = ldist * 40.0 * 170 / 1000000;

            return
                new Report
                {
                    Distance = dist,
                    Illuminance = buffer[5],
                    IsShaking = (buffer[6] & 0x01) == 0x01,
                    TimeStamp = DateTime.Now,
                    IsBuzzerOn = (buffer[6] & 0x02) == 0x02,
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
