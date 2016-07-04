using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlarmSystem.Entity;

namespace AlarmSystem.DAL
{
    public static class ProfileKeeper
    {
        private const string ProfileFileName = "cfg.bin";

        private static string GetProfilePath() => AppDomain.CurrentDomain.BaseDirectory + ProfileFileName;

        public static bool IsExists() => File.Exists(GetProfilePath());

        public static Profile LoadProfile()
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(GetProfilePath(), FileMode.Open, FileAccess.Read, FileShare.Read))
                return (Profile)formatter.Deserialize(stream);
        }

        public static void SaveProfile(Profile profile)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(GetProfilePath(), FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(stream, profile);
        }
    }
}
