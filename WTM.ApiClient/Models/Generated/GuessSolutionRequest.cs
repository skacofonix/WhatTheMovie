﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using Newtonsoft.Json.Linq;

namespace WTM.ApiClient.Models
{
    public partial class GuessSolutionRequest
    {
        private string title;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        
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
        /// Initializes a new instance of the GuessSolutionRequest class.
        /// </summary>
        public GuessSolutionRequest()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the GuessSolutionRequest class with
        /// required arguments.
        /// </summary>
        public GuessSolutionRequest(string title)
            : this()
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }
            this.Title = title;
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type GuessSolutionRequest
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Title == null)
            {
                throw new ArgumentNullException("Title");
            }
            if (this.Title != null)
            {
                outputObject["Title"] = this.Title;
            }
            if (this.Token != null)
            {
                outputObject["Token"] = this.Token;
            }
            return outputObject;
        }
    }
}