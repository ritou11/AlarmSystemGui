using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace alarm
{
    public class AckFrame
    {
        public byte len;
        public byte type;
        public byte[] cont;
        public byte lcs, rcs;
        public AckFrame() { len = type = 0; }
        public AckFrame(byte[] src)
        {
            if ((src[0] + src[1] & 0xFF) != 0) return;
            len = src[0];
            lcs = src[1];
            if (src.Length < len + 4)
            {
                len = 0;
                return;
            }
            if (src[2] != 0xD5) return;
            type = src[3];
            cont = src.Skip(4).Take(len - 2).ToArray();
            rcs = src[len + 2];
        }
        public bool CheckSelf()
        {
            if (((len + lcs) & 0xFF) != 0) return false;
            byte cc = (byte)(type + 0xD5);
            foreach (byte b in cont) cc += b;
            if (((cc + rcs) & 0xFF) != 0) return false;
            return true;
        }
    }
    public static class Command
    {
        public static string Wakeup = "55 55 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF 03 FD D4 14 01 17 00";
        public static string ReadUID = "00 00 FF 04 FC D4 4A 01 00 E1 00";
        public static string ReadCard = "libnfc 1.7.1 write";
        public static string TargetInit = "00 00 FF 2B D5 D4 8C 02 08 00 12 34 56 40 01 FE 12 34 56 78 90 12 C0 C1 C2 C3 C4 C5 C6 C7 0F AB 12 34 56 78 9A BC DE FF 00 00 04 12 34 56 78 00 D0 00";
        public static string SetParameters = "00 00 FF 03 FD D4 12 14 06 00";
        public static string CheckCommunication = "00 00 FF 09 F7 D4 00 00 6C 69 62 6E 66 63 BE 00";
        public static string CheckVersion = "00 00 FF 02 FE D4 02 2A 00";
        public static string TgGetData = "00 00 ff 02 fe d4 86 a6 00";
        public static string TgSetData = "00 00 FF 08 F8 D4 8E 74 61 72 67 65 74 17 00";

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
        public static void calcCommand(out byte[] byteBuffer, byte[] tmpBuffer)
        {
            byteBuffer = new byte[tmpBuffer.Length + 8];//00 00 FF LEN LCS D4 ....... DCS 00
            byteBuffer[0] = 0;
            byteBuffer[1] = 0;
            byteBuffer[2] = 0xFF;
            byteBuffer[3] = (byte)(tmpBuffer.Length + 1);
            byteBuffer[4] = (byte)(0x100 - byteBuffer[3]);
            byteBuffer[5] = 0xD4;
            for (int i = 6; i < byteBuffer.Length - 2; i++)
            {
                byteBuffer[i] = tmpBuffer[i - 6];
            }
            byte sum = 0xD4;
            foreach (byte b in tmpBuffer)
            {
                sum += b;
            }
            byteBuffer[byteBuffer.Length - 2] = (byte)(0x100 - sum);
            byteBuffer[byteBuffer.Length - 1] = 0;
        }
        public static byte[] InDataExchange(byte Tg,byte[] DataIn) {
            byte[] tmpBuffer = new byte[DataIn.Length+2];
            tmpBuffer[0] = 0x40;
            tmpBuffer[1] = Tg;
            DataIn.CopyTo(tmpBuffer, 2);
            byte[] re;
            calcCommand(out re,tmpBuffer);
            return re;
        }
        public static byte[] InDataExchange(byte Tg, params string[] cmd)
        {
            byte[] DataIn;
            dealCommand(out DataIn,cmd);
            byte[] tmpBuffer = new byte[DataIn.Length + 2];
            tmpBuffer[0] = 0x40;
            tmpBuffer[1] = Tg;
            DataIn.CopyTo(tmpBuffer, 2);
            byte[] re;
            calcCommand(out re, tmpBuffer);
            return re;
        }
        public static string getStrWriteData4(string data)
        {
            return "00 00 FF 15 EB D4 40 01 A0 02 " + data;
        }
        public static string getStrWriteData7(string data)
        {
            return "00 00 FF 09 F7 D4 40 01 A2 04 " + data;
        }
        public static IEnumerable<AckFrame> getFrame(byte[] src)
        {
            for(int i=0;i<src.Length-2;i++)
                if (src[i] == 0x00 && src[i + 1] == 0x00 && src[i + 2] == 0xFF)
                {
                    AckFrame ack = new AckFrame(src.Skip(i+3).ToArray());
                    if(ack.len>0)  yield return ack;
                }
        }
    }
}
