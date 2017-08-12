using System;
using System.IO;
using System.Runtime.Serialization.Json;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem
{
    public class UserData
    {
        public string UserAccessToken { get; set; }

        public Location WindowStart { get; set; }

        private static string s_UserDataFilePath = Environment.CurrentDirectory + @"\UserData.txt";

        public bool RememberLogIn { get; set; }

        public bool Connected { get; set; }

        public static UserData LoadUserDataFromJson()
        {
            try
            {
                using (FileStream fileStream = new FileStream(s_UserDataFilePath, FileMode.Open))
                {
                    DataContractJsonSerializer serilizer = new DataContractJsonSerializer(typeof(UserData));
                    UserData retVal = new UserData();
                    return retVal = (UserData)serilizer.ReadObject(fileStream);
                }
            }
            catch
            {
                return new UserData();
            }
        }

        public string GetUserDataFilePath()
        {
            return s_UserDataFilePath;
        }

        public void SaveUserDataToJson()
        {
            FileMode fileMode;

            if (File.Exists(s_UserDataFilePath))
            {
                fileMode = FileMode.Truncate;
            }
            else
            {
                fileMode = FileMode.OpenOrCreate;
            }

            try
            {
                using (FileStream fileStream = new FileStream(s_UserDataFilePath, fileMode))
                {
                    DataContractJsonSerializer serilizer = new DataContractJsonSerializer(typeof(UserData));
                    serilizer.WriteObject(fileStream, this);
                }
            }
            catch
            {
                throw new Exception("Hoo no, Unable to Save your preferance for next time...");
            }
        }

        public void DeleteUserDataFile()
        {
            try
            {
                File.Delete(s_UserDataFilePath);
            }
            catch
            {
            }
        }
    }
}
