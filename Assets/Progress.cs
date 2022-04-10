using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Net;
using System;
using UnityEngine;

namespace UG 
{
    public class Progress
    {
        [DllImport("__Internal")]
        private static extern void save(string data); // JavaScript function

        [DllImport("__Internal")]
        private static extern string load(); // JavaScript function

        public static void Save(string data)
        {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
            save(data);
#else
            PlayerPrefs.SetString("data", data);
#endif
        }

        public static string Load()
        {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
            return load();
#else
            return PlayerPrefs.GetString("data");
#endif
        }
    }
}

