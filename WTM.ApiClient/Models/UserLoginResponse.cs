﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using Newtonsoft.Json.Linq;

namespace WTM.ApiClient.Models
{
    public partial class UserLoginResponse
    {
        private string token;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the UserLoginResponse class.
        /// </summary>
        public UserLoginResponse()
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
