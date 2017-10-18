#region Copyright (c) 2004 Atif Aziz. All rights reserved.
//
// ELMAH - Error Logging Modules and Handlers for ASP.NET
// Copyright (c) 2004 Atif Aziz. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

namespace Elmah
{
    #region Imports

    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.IO;
    using System.Runtime.CompilerServices;
    using IDictionary = System.Collections.IDictionary;

    #endregion

    /// <summary>
    /// Helper class for resolving connection strings.
    /// </summary>

    static class ConnectionStringHelper
    {
        /// <summary>
        /// Gets the connection string from the given configuration 
        /// dictionary.
        /// </summary>

        public static string GetConnectionString(IDictionary config)
        {
          System.Diagnostics.Debug.Assert(config != null);

          //
            // First look for a connection string name that can be 
            // subsequently indexed into the <connectionStrings> section of 
            // the configuration to get the actual connection string.
            //

            var connectionStringName = config.Find("connectionStringName", string.Empty);

            if (connectionStringName.Length > 0)
            {
                var settings = ConfigurationManager.ConnectionStrings[connectionStringName];

                if (settings == null)
                    return string.Empty;

                return settings.ConnectionString ?? string.Empty;
            }

            //
            // Connection string name not found so see if a connection 
            // string was given directly.
            //

            var connectionString = config.Find("connectionString", string.Empty);
            if (connectionString.Length > 0)
                return connectionString;

            //
            // As a last resort, check for another setting called 
            // connectionStringAppKey that specifies the key in 
            // <appSettings> that contains the actual connection string to 
            // be used.
            //

            var connectionStringAppKey = config.Find("connectionStringAppKey", string.Empty);
            return connectionStringAppKey.Length > 0 
                 ? ConfigurationManager.AppSettings[connectionStringAppKey] 
                 : string.Empty;
        }
    }
}
