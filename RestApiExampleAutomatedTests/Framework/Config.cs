using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;


namespace RestApiExampleAutomatedTests.Framework
{
    public static class Config
    {
        /// <summary>
        /// Main URL of the Web and API
        /// </summary>
        public static string QaHost
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["QaAppHost"];
            }
        }

        /// <summary>
        /// Database Host
        /// </summary>
        public static string DbHost
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["DbHost"];
            }
        }

        /// <summary>
        /// Database Login
        /// </summary>
        public static string DbLogin
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["DbLogin"];
            }
        }

        /// <summary>
        /// Database Password
        /// </summary>
        public static string DbPassword
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["DbPassword"];
            }
        }

        /// <summary>
        /// Database Default Name
        /// </summary>
        public static string DbTerm
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["DbTerm"];
            }
        }
    }
}
