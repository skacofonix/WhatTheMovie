﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WTM.RestApi.Client.Models
{
    public partial class TagsAddRequest
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
        
        private string _token;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the TagsAddRequest class.
        /// </summary>
        public TagsAddRequest()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the TagsAddRequest class with
        /// required arguments.
        /// </summary>
        public TagsAddRequest(string tag, string token)
            : this()
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            this.Tag = tag;
            this.Token = token;
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type TagsAddRequest
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Tag == null)
            {
                throw new ArgumentNullException("Tag");
            }
            if (this.Token == null)
            {
                throw new ArgumentNullException("Token");
            }
            if (this.Tag != null)
            {
                outputObject["Tag"] = this.Tag;
            }
            if (this.Token != null)
            {
                outputObject["Token"] = this.Token;
            }
            return outputObject;
        }
    }
}
