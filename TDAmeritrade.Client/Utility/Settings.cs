// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Utility
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    using Microsoft.Win32;

    internal static class Settings
    {
        internal static bool Get(string name, bool defaultValue)
        {
            var key = Registry.CurrentUser.CreateSubKey("Software\\KriaSoft\\TD Ameritrade Client Library for .NET");
            var value = (int?)key.GetValue(name);

            if (value.HasValue)
            {
                return value.Value == 1;
            }

            key.SetValue(name, defaultValue, RegistryValueKind.DWord);
            return defaultValue;
        }

        internal static T Get<T>(string name, Func<T> defaultValue = null) where T : class
        {
            var key = Registry.CurrentUser.CreateSubKey("Software\\KriaSoft\\TD Ameritrade Client Library for .NET");
            var value = key.GetValue(name) as T;

            if (defaultValue != null && value == null)
            {
                value = defaultValue();
                key.SetValue(name, value);
            }

            return value;
        }

        internal static void Set(string name, bool value)
        {
            Registry.CurrentUser.CreateSubKey("Software\\KriaSoft\\TD Ameritrade Client Library for .NET").SetValue(name, value, RegistryValueKind.DWord);
        }

        internal static void Set<T>(string name, T value)
        {
            Registry.CurrentUser.CreateSubKey("Software\\KriaSoft\\TD Ameritrade Client Library for .NET").SetValue(name, value);
        }

        internal static string GetProtected(string name)
        {
            var encryptedData = Get<byte[]>(name);

            if (encryptedData == null)
            {
                return null;
            }

            var entropy = GetEntropy();
            var data = ProtectedData.Unprotect(encryptedData, entropy, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(data);
        }

        internal static void SetProtected(string name, string value)
        {
            var entropy = GetEntropy();
            var encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(value), entropy, DataProtectionScope.CurrentUser);
            Set(name, encryptedData);
        }

        private static byte[] GetEntropy()
        {
            return Get(
                "Entropy",
                defaultValue: () =>
                {
                    var val = new byte[20];

                    using (var rng = new RNGCryptoServiceProvider())
                    {
                        rng.GetBytes(val);
                    }

                    return val;
                });
        }
    }
}
