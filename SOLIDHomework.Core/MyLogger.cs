﻿using System.Configuration;
using System.IO;

namespace SOLIDHomework.Core
{
    public class MyLogger
    {
        private readonly string filePath;

        public MyLogger()
        {
            filePath = ConfigurationManager.AppSettings["logPath"];
        }

        public void Write(string text)
        {
            using (Stream file = File.OpenWrite(filePath))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}
