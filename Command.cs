using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace alarm
{
    public class AlarmStatus
    {
        //TODO: Find suitable parameters
        const int MaxDist = 5;
        const byte MaxIllum = 5;

        public enum State
        {
            S_DISABLED,
            S_NORM,
            S_A1,
            S_A2,
            S_A3,
            S_A4,
            S_ERR
        }
        // represent if the value is normal
        private bool isConnected;
        private bool isIllum;
        private bool isDist;
        private bool isAlc2;

        private bool isDisabled;
        public State AssertState()
        {
            //TODO: More complicated rules
            if (isDisabled) return State.S_DISABLED;
            if (!isConnected) return State.S_A4;
            if (!isAlc2) return State.S_A3;
            if (!isIllum) return State.S_A2;
            if (!isDist) return State.S_A1;
            return State.S_NORM;
        }
        public State Update(int dist, byte illum, bool acl2, bool conn, bool disabled)
        {
            isDist = (dist < MaxDist);
            isIllum = (illum < MaxIllum);
            isConnected = conn;
            isAlc2 = !acl2;
            isDisabled = disabled;
            return AssertState();
        }
    }
    public class AlarmFrame
    {
        public int start_i;
        public int dist;
        public byte illum;
        public bool acl2;
        public AlarmFrame() { }
        public AlarmFrame(int DIST,byte ILLUM, bool ACL2, int I)
        {
            dist = DIST;
            illum = ILLUM;
            acl2 = ACL2;
            start_i = I;
        }
    }
    public static class Command
    {
        /*Translate string hex into bytes hex*/
        public static bool dealCommand(out byte[] byteBuffer,params string[] cmd)
        {
            StringBuilder strSend = new StringBuilder();
            foreach (string s in cmd)
            {
                strSend.Append(' ');
                strSend.Append(s);
            }
            string sendBuf = strSend.ToString();
            string sendnoNull = sendBuf.Trim();
            string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
            string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
            string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
            strSendNoComma2.Replace("0X", "");   //去掉0X
            string[] strArray = strSendNoComma2.Split(' ');

            int byteBufferLength = strArray.Length;

            for (int i = 0; i < strArray.Length; i++)
                if (strArray[i] == "")
                    byteBufferLength--;

            byteBuffer = new byte[byteBufferLength];

            int j = 0;
            int decNum = 0;

            for (int i = 0; i < strArray.Length; i++) 
            {
                //Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);
                if (strArray[i] == "") continue;
                else
                {
                    decNum = Convert.ToInt32(strArray[i], 16);
                    try
                    {
                        byteBuffer[j] = Convert.ToByte(decNum);
                    }
                    catch (System.Exception)
                    {
                        return false;
                    }
                    j++;
                }
            }
            return true;
        }
        /*Constructure a piece of command*/
        public static void calcCommand(out byte[] byteBuffer,params string[] content)
        {
            StringBuilder strSend=new StringBuilder();
            foreach(string s in content)
            {
                strSend.Append(' ');
                strSend.Append(s);
            }
            byte[] tmpBuffer;
            dealCommand(out tmpBuffer, strSend.ToString());
            byteBuffer = new byte[tmpBuffer.Length+8];//00 00 FF LEN LCS D4 ....... DCS 00
            byteBuffer[0] = 0;
            byteBuffer[1] = 0;
            byteBuffer[2] = 0xFF;
            byteBuffer[3] = (byte)(tmpBuffer.Length+1);
            byteBuffer[4] = (byte)(0x100 - byteBuffer[3]);
            byteBuffer[5] = 0xD4;
            for(int i = 6; i < byteBuffer.Length - 2; i++)
            {
                byteBuffer[i] = tmpBuffer[i - 6];
            }
            byte sum=0xD4;
            foreach(byte b in tmpBuffer)
            {
                sum += b;
            }
            byteBuffer[byteBuffer.Length-2]=(byte)(0x100- sum);
            byteBuffer[byteBuffer.Length - 1] = 0;
        }

        public static IEnumerable<AlarmFrame> getFrame(byte[] src)
        {
            for (int i = 0; i < src.Length - 8; i++) if (src[i] == 0x5A)
                {
                    byte chk;
                    chk = (byte)(src[i + 4] ^ src[i + 5] ^ src[i + 6]);
                    if (chk == src[i + 7])
                    {
                        int dist = (src[i + 1] << 12) + (src[i + 2] << 8) + (src[i + 3] << 4) + src[i + 4];
                        dist = dist * 40 * 170 / 1000000;
                        byte illum = src[i + 5];
                        bool acl2 = (src[i + 6] == 1);
                        yield return new AlarmFrame(dist, illum, acl2, i);
                    }
                }
        }
    }
}
