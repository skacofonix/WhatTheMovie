﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using Newtonsoft.Json.Linq;

namespace WTM.ApiClient.Models
{
    public partial class ShotSummary
    {
        private int id;
        
        /// <summary>
        /// Required.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        private string status;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        
        private string thumb;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Thumb
        {
            get { return this.thumb; }
            set { this.thumb = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the IShotSummary class.
        /// </summary>
        public ShotSummary()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the IShotSummary class with required
        /// arguments.
        /// </summary>
        public ShotSummary(int id, string thumb, string status)
            : this()
        {
            if (thumb == null)
            {
                throw new ArgumentNullException("thumb");
            }
            if (status == null)
            {
                throw new ArgumentNullException("status");
            }
            this.Id = id;
            this.Thumb = thumb;
            this.Status = status;
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken statusValue = inputObject["Status"];
                if (statusValue != null && statusValue.Type != JTokenType.Null)
                {
                    this.Status = ((string)statusValue);
                }
                JToken thumbValue = inputObject["Thumb"];
                if (thumbValue != null && thumbValue.Type != JTokenType.Null)
                {
                    this.Thumb = ((string)thumbValue);
                }
            }
        }
    }
}
