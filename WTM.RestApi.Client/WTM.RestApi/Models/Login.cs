﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WTM.RestApi.Client.Models
{
    public partial class Login
    {
        private string _token;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Login class.
        /// </summary>
        public Login()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken tokenValue = inputObject["Token"];
                if (tokenValue != null && tokenValue.Type != JTokenType.Null)
                {
                    this.Token = ((string)tokenValue);
                }
            }
        }
    }
}