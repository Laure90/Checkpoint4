﻿using System.Text;
using System.Security.Cryptography;

namespace Checkpoint4_App
{
    public static class Sha256Tools
    {
        public static string GetHash(string input)
        {
            SHA256 sha256Hash = SHA256.Create();

            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();

        }
    }
}

