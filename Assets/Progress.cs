using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Net;
using System;
using UnityEngine;

namespace UG 
{
    public class Progress 
    {
        [Serializable]
        private class ProgressData
        {
            public string user = "";
            public int checkpointsCollected = 0;
            public string data = "{}";
        }

        [Serializable]
        private class LoadProgressData 
        {
            public List<ProgressData> objects = new List<ProgressData>();
        }

        public static void Save(string gameId, int checkpointsCollected, string data)
        {
            WebRequest request = WebRequest.Create($"https://api.urfugames.ru/games/{gameId}/progress");
            request.Method = "POST";
            request.ContentType = "application/json";
            // TODO
            string body = $"{{ \"user\": \"9740b943-2f68-42c7-a3c3-d245e40803b3\", \"checkpointsCollected\": {checkpointsCollected}, \"data\": \"{data.Replace("\"", "\\\"")}\" }}";
            byte[] bodyBytes = System.Text.Encoding.UTF8.GetBytes(body);
            request.ContentLength = bodyBytes.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(bodyBytes, 0, bodyBytes.Length);
            }

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Debug.Log(reader.ReadToEnd());
                }
            }

            response.Close();
        }

        public static T Load<T>(string gameId)
        {
            ProgressData progressData = new ProgressData();

            WebRequest request = WebRequest.Create($"https://api.urfugames.ru/games/{gameId}/progress?users=9740b943-2f68-42c7-a3c3-d245e40803b3");

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    progressData = JsonUtility.FromJson<LoadProgressData>($"{{ \"objects\": {reader.ReadToEnd()} }}").objects[0];
                }
            }

            Debug.Log(progressData.data);

            return JsonUtility.FromJson<T>(progressData.data);
        }
    }
}
