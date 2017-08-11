using C17_Ex01_Tal_301349361_Ori_2033199900.FilelSystem;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem
{
    public class UserData : IDataUsable
    {
        public string UserAccessToken { get; set; }
        public Location WindowStart { get; set; }
        private static string s_UserDataFilePath = Environment.CurrentDirectory + @"\UserData.txt";
        public bool RememberLogIn { get; set; }

        public void saveUserDataToJson()
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

            using (FileStream fileStream = new FileStream(s_UserDataFilePath, fileMode))
            {
                DataContractJsonSerializer serilizer = new DataContractJsonSerializer(typeof(UserData));
                serilizer.WriteObject(fileStream, this);
            }
        }

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
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
