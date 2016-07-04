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
        public State Update(uint dist, byte illum, bool acl2, bool conn, bool disabled)
        {
            isDist = (dist < MaxDist);
            isIllum = (illum < MaxIllum);
            isConnected = conn;
            isAlc2 = !acl2;
            isDisabled = disabled;
            return AssertState();
        }
        public State LostConnection()
        {
            isConnected = false;
            return AssertState();
        }
    }
    public class AlarmFrame
    {
        public int start_i;
        public uint dist;
        public byte illum;
        public bool acl2;
        public AlarmFrame() { }
        public AlarmFrame(uint DIST,byte ILLUM, bool ACL2, int I)
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
        public static IEnumerable<AlarmFrame> getFrame(byte[] src)
        {
            for (int i = 0; i < src.Length - 8; i++) if (src[i] == 0x5A)
                {
                    byte chk;
                    chk = (byte)(src[i + 4] ^ src[i + 5] ^ src[i + 6]);
                    if (chk == src[i + 7])
                    {
                        byte[] distbyte=new byte[]{src[i+4],src[i+3],src[i+2],src[i+1]};
                        uint dist = BitConverter.ToUInt32(distbyte, 0);                        
                        dist = dist * 40 * 174 / 10000000;
                        byte illum = src[i + 5];
                        bool acl2 = (src[i + 6] == 1);
                        yield return new AlarmFrame(dist, illum, acl2, i);
                    }
                }
        }
    }
}
