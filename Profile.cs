using System;

namespace AlarmSystem
{
    internal class Profile
    {
        public static void LoadProfile()
        {
            var strPath = AppDomain.CurrentDomain.BaseDirectory;
            m_File = new IniFile(strPath + "Cfg.ini");
            GBaudrate = m_File.ReadString("CONFIG", "BaudRate", "115200"); //读数据，下同
            GDatabits = m_File.ReadString("CONFIG", "DataBits", "8");
            GStop = m_File.ReadString("CONFIG", "StopBits", "1");
            GParity = m_File.ReadString("CONFIG", "Parity", "NONE");
        }

        public static void SaveProfile()
        {
            var strPath = AppDomain.CurrentDomain.BaseDirectory;
            m_File = new IniFile(strPath + "Cfg.ini");
            m_File.WriteString("CONFIG", "BaudRate", GBaudrate); //写数据，下同
            m_File.WriteString("CONFIG", "DataBits", GDatabits);
            m_File.WriteString("CONFIG", "StopBits", GStop);
            m_File.WriteString("CONFIG", "G_PARITY", GParity);
        }

        private static IniFile m_File; //内置了一个对象

        public static string GBaudrate = "1200"; //给ini文件赋新值，并且影响界面下拉框的显示
        public static string GDatabits = "8";
        public static string GStop = "1";
        public static string GParity = "NONE";
    }
}
