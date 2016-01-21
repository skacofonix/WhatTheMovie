﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;

namespace WTM.RestApi.Client.Models
{
    public partial class IShotSearchRequest
    {
        private string _tag;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Tag
        {
            get { return this._tag; }
            set { this._tag = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the IShotSearchRequest class.
        /// </summary>
        public IShotSearchRequest()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the IShotSearchRequest class with
        /// required arguments.
        /// </summary>
        public IShotSearchRequest(string tag)
            : this()
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }
            this.Tag = tag;
        }
    }
}
