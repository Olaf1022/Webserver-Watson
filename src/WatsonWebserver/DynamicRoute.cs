﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WatsonWebserver
{
    /// <summary>
    /// Assign a method handler for when requests are received matching the supplied method and path regex.
    /// </summary>
    public class DynamicRoute
    {
        #region Public-Members

        /// <summary>
        /// Globally-unique identifier.
        /// </summary>
        [JsonPropertyOrder(-1)]
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// The HTTP method, i.e. GET, PUT, POST, DELETE, etc.
        /// </summary>
        [JsonPropertyOrder(0)]
        public HttpMethod Method { get; set; } = HttpMethod.GET;

        /// <summary>
        /// The pattern against which the raw URL should be matched.  
        /// </summary>
        [JsonPropertyOrder(1)]
        public Regex Path { get; set; } = null;

        /// <summary>
        /// The handler for the dynamic route.
        /// </summary>
        [JsonIgnore]
        public Func<HttpContext, Task> Handler { get; set; } = null;

        /// <summary>
        /// User-supplied metadata.
        /// </summary>
        [JsonPropertyOrder(999)]
        public object Metadata { get; set; } = null;

        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Create a new route object.
        /// </summary>
        /// <param name="method">The HTTP method, i.e. GET, PUT, POST, DELETE, etc.</param>
        /// <param name="path">The pattern against which the raw URL should be matched.</param>
        /// <param name="handler">The method that should be called to handle the request.</param>
        /// <param name="guid">Globally-unique identifier.</param>
        /// <param name="metadata">User-supplied metadata.</param>
        public DynamicRoute(HttpMethod method, Regex path, Func<HttpContext, Task> handler, string guid = null, object metadata = null)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            Method = method;
            Path = path;
            Handler = handler;

            if (!String.IsNullOrEmpty(guid)) GUID = guid;
            if (metadata != null) Metadata = metadata;
        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
