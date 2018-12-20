using System;
using System.Collections.Generic;

namespace CMTC.Utilities
{
    public static class ApplicationSettings
    {
        private static List<KeyValuePair<string, string>> _settings = new List<KeyValuePair<string, string>>();

        public static void AppySettings(string[] args)
        {
            if (args.Length >= 1)
            {
                foreach (var argument in args)
                {
                    if (argument.StartsWith("-o"))
                    {
                        Set("output", argument.Substring(2));
                    }
                }

                return;
            }

            throw new Exception(TemplateManager.GetTemplate("NO_PARAMS").Render());
        }

        public static string Get(string key)
        {
            return _settings.Find(s => s.Key.Equals(key)).Value;
        }

        public static void Set(string key, string value)
        {
            _settings.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
