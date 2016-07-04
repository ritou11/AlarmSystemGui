using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem
{
    public class AlarmStatus
    {
        //TODO: Find suitable parameters
        private const int MaxDist = 5;
        private const byte MaxIllum = 5;

        public enum State
        {
            Disabled,
            Norm,
            A1,
            A2,
            A3,
            A4,
            Err
        }

        // represent if the value is normal
        private bool m_IsConnected;
        private bool m_IsIllum;
        private bool m_IsDist;
        private bool m_IsAlc2;

        private bool m_IsDisabled;

        public State AssertState()
        {
            //TODO: More complicated rules
            if (m_IsDisabled)
                return State.Disabled;
            if (!m_IsConnected)
                return State.A4;
            if (!m_IsAlc2)
                return State.A3;
            if (!m_IsIllum)
                return State.A2;
            if (!m_IsDist)
                return State.A1;
            return State.Norm;
        }

        public State Update(int dist, byte illum, bool acl2, bool conn, bool disabled)
        {
            m_IsDist = (dist < MaxDist);
            m_IsIllum = (illum < MaxIllum);
            m_IsConnected = conn;
            m_IsAlc2 = !acl2;
            m_IsDisabled = disabled;
            return AssertState();
        }
    }

    public class AlarmFrame
    {
        public int StartI;
        public int Dist;
        public byte Illum;
        public bool Acl2;

        public AlarmFrame(int DIST, byte ILLUM, bool ACL2, int I)
        {
            Dist = DIST;
            Illum = ILLUM;
            Acl2 = ACL2;
            StartI = I;
        }
    }

    public static class Command
    {
        /*Translate string hex into bytes hex*/

        public static bool DealCommand(out byte[] byteBuffer, params string[] cmd)
        {
            var strSend = new StringBuilder();
            foreach (var s in cmd)
            {
                strSend.Append(' ');
                strSend.Append(s);
            }
            var sendBuf = strSend.ToString();
            var sendnoNull = sendBuf.Trim();
            var sendNoComma = sendnoNull.Replace(',', ' '); //去掉英文逗号
            var sendNoComma1 = sendNoComma.Replace('，', ' '); //去掉中文逗号
            var strSendNoComma2 = sendNoComma1.Replace("0x", ""); //去掉0x
            strSendNoComma2.Replace("0X", ""); //去掉0X
            var strArray = strSendNoComma2.Split(' ');

            var byteBufferLength = strArray.Length;

            for (var i = 0; i < strArray.Length; i++)
                if (strArray[i] == "")
                    byteBufferLength--;

            byteBuffer = new byte[byteBufferLength];

            var j = 0;
            var decNum = 0;

            for (var i = 0; i < strArray.Length; i++)
            {
                //Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);
                if (strArray[i] == "")
                    continue;
                decNum = Convert.ToInt32(strArray[i], 16);
                try
                {
                    byteBuffer[j] = Convert.ToByte(decNum);
                }
                catch (Exception)
                {
                    return false;
                }
                j++;
            }
            return true;
        }

        /*Constructure a piece of command*/

        public static void CalcCommand(out byte[] byteBuffer, params string[] content)
        {
            var strSend = new StringBuilder();
            foreach (var s in content)
            {
                strSend.Append(' ');
                strSend.Append(s);
            }
            byte[] tmpBuffer;
            DealCommand(out tmpBuffer, strSend.ToString());
            byteBuffer = new byte[tmpBuffer.Length + 8]; //00 00 FF LEN LCS D4 ....... DCS 00
            byteBuffer[0] = 0;
            byteBuffer[1] = 0;
            byteBuffer[2] = 0xFF;
            byteBuffer[3] = (byte)(tmpBuffer.Length + 1);
            byteBuffer[4] = (byte)(0x100 - byteBuffer[3]);
            byteBuffer[5] = 0xD4;
            for (var i = 6; i < byteBuffer.Length - 2; i++)
                byteBuffer[i] = tmpBuffer[i - 6];
            byte sum = 0xD4;
            foreach (var b in tmpBuffer)
                sum += b;
            byteBuffer[byteBuffer.Length - 2] = (byte)(0x100 - sum);
            byteBuffer[byteBuffer.Length - 1] = 0;
        }

        public static IEnumerable<AlarmFrame> GetFrame(byte[] src)
        {
            for (var i = 0; i < src.Length - 8; i++)
                if (src[i] == 0x5A)
                {
                    byte chk;
                    chk = (byte)(src[i + 4] ^ src[i + 5] ^ src[i + 6]);
                    if (chk == src[i + 7])
                    {
                        var dist = (src[i + 1] << 12) + (src[i + 2] << 8) + (src[i + 3] << 4) + src[i + 4];
                        dist = dist * 40 * 170 / 1000000;
                        var illum = src[i + 5];
                        var acl2 = (src[i + 6] == 1);
                        yield return new AlarmFrame(dist, illum, acl2, i);
                    }
                }
        }
    }
}
