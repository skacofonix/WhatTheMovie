﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using Newtonsoft.Json.Linq;

namespace WTM.ApiClient.Models
{
    public partial class ShotMovieSolution
    {
        private string id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        private string title;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        
        private int? year;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the IShotMovieSolution class.
        /// </summary>
        public ShotMovieSolution()
        {
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
                    this.Id = ((string)idValue);
                }
                JToken titleValue = inputObject["Title"];
                if (titleValue != null && titleValue.Type != JTokenType.Null)
                {
                    this.Title = ((string)titleValue);
                }
                JToken yearValue = inputObject["Year"];
                if (yearValue != null && yearValue.Type != JTokenType.Null)
                {
                    this.Year = ((int)yearValue);
                }
            }
        }
    }
}
