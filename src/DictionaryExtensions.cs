#region Copyright 2004 Atif Aziz. All rights reserved.
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
    using System.Collections;

    #endregion

    static class DictionaryExtensions
    {
        public static T Find<T>(this IDictionary dict, object key, T @default)
        {
            if (dict == null) throw new ArgumentNullException("dict");
            return (T) (dict[key] ?? @default);
        }
    }
}
