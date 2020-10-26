/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantConnect.Securities.Future
{
    /// <summary>
    /// CME options category list API call root response
    /// </summary>
    public class CMEOptionsCategoryListEntry
    {
        /// <summary>
        /// Describes the type of future option this entry is
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; private set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Option type. "AME" for American, "EUR" for European.
        /// Note that there are other types such as weekly, but we
        /// only support American options for now.
        /// </summary>
        [JsonProperty("optionType")]
        public string OptionType { get; private set; }

        /// <summary>
        /// Is Daily option
        /// </summary>
        [JsonProperty("daily")]
        public bool Daily { get; private set; }

        /// <summary>
        /// ???
        /// </summary>
        [JsonProperty("sto")]
        public bool Sto { get; private set; }

        /// <summary>
        /// Is weekly option
        /// </summary>
        [JsonProperty("weekly")]
        public bool Weekly { get; private set; }

        /// <summary>
        /// Expirations of the future option
        /// </summary>
        [JsonProperty("expirations")]
        public Dictionary<string, CMEOptionsCategoryExpiration> Expirations { get; private set; }
    }

    /// <summary>
    /// Future options Expiration entries. These are useful because we can derive the
    /// future chain from this data, since FOP and FUT share a 1-1 expiry code.
    /// </summary>
    public class CMEOptionsCategoryExpiration
    {
        /// <summary>
        /// Date of expiry
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; private set; }

        /// <summary>
        /// Product ID of the expiring asset (usually future option)
        /// </summary>
        [JsonProperty("productId")]
        public int ProductId { get; private set; }

        /// <summary>
        /// Contract month code formatted as [FUTURE_MONTH_LETTER(1)][YEAR(1)]
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; private set; }
    }
}