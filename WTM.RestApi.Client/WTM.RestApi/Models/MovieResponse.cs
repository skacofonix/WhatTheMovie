﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using WTM.RestApi.Client.Models;

namespace WTM.RestApi.Client.Models
{
    public partial class MovieResponse
    {
        private string _data;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
        
        private Error _error;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Error Error
        {
            get { return this._error; }
            set { this._error = value; }
        }
        
        private Pagination _pagination;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Pagination Pagination
        {
            get { return this._pagination; }
            set { this._pagination = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the MovieResponse class.
        /// </summary>
        public MovieResponse()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken dataValue = inputObject["Data"];
                if (dataValue != null && dataValue.Type != JTokenType.Null)
                {
                    this.Data = dataValue.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                JToken errorValue = inputObject["Error"];
                if (errorValue != null && errorValue.Type != JTokenType.Null)
                {
                    Error error = new Error();
                    error.DeserializeJson(errorValue);
                    this.Error = error;
                }
                JToken paginationValue = inputObject["Pagination"];
                if (paginationValue != null && paginationValue.Type != JTokenType.Null)
                {
                    Pagination pagination = new Pagination();
                    pagination.DeserializeJson(paginationValue);
                    this.Pagination = pagination;
                }
            }
        }
    }
}
