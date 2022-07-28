﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace WatsonWebserver
{
    /// <summary>
    /// Access control mode of operation.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessControlMode
    {
        /// <summary>
        /// Permit requests from any endpoint by default.
        /// </summary>
        [EnumMember(Value = "DefaultPermit")]
        DefaultPermit,
        /// <summary>
        /// Deny requests from any endpoint by default.
        /// </summary>
        [EnumMember(Value = "DefaultDeny")]
        DefaultDeny
    }
}
