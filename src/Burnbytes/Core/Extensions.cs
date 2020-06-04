using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Burnbytes
{
    internal static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumarable, Action<T> action)
        {
            foreach (var item in enumarable)
            {
                action.Invoke(item);
            }
        }

        public static Icon AsDisposableIcon(this Icon icon)
        {
            // System.Drawing.Icon does not expose a method to declare
            // ownership of its wrapped handle so we have to use reflection
            // here.

            // See also: https://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Icon.cs,71

            icon.GetType().GetField("ownHandle", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(icon, true);
            return icon;
        }

        public static string ToReadableString(this long bytes)
        {
            var norm = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            var count = norm.Length - 1;
            decimal size = bytes;
            int x = 0;

            while (size >= 1000 && x < count)
            {
                size /= 1024;
                x++;
            }

            return string.Format($"{Math.Round(size, 2)} {norm[x]}", MidpointRounding.AwayFromZero);
        }

        public static string Format(this string @string, params object[] args) => string.Format(@string, args);


        public static void Localize<T>(this ResourceManager resourceManager, params Control[] controls)
        {
            foreach (var control in controls)
            {
                try
                {
                    control.Text = resourceManager.GetString($"{typeof(T).Name}_{control.Name}");
                }
                catch (Exception)
                {
                    control.Text = "Localization failed!";
                }

            }

        }
    }
}
