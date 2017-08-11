using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    public interface ILogicInterface
    {
        void LogInToSocialNetwork();
        UserData GetUserData();


        //////////////////////////////////////
        // remove this test method
        //////////////////////////////////////
        List<string> Data();
    }
}
