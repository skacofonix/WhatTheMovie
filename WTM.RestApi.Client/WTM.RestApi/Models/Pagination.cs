﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace WTM.RestApi.Client.Models
{
    public partial class Pagination
    {
        private int? _first;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? First
        {
            get { return this._first; }
            set { this._first = value; }
        }
        
        private int? _last;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Last
        {
            get { return this._last; }
            set { this._last = value; }
        }
        
        private int? _limit;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Limit
        {
            get { return this._limit; }
            set { this._limit = value; }
        }
        
        private int? _start;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Start
        {
            get { return this._start; }
            set { this._start = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Pagination class.
        /// </summary>
        public Pagination()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken firstValue = inputObject["First"];
                if (firstValue != null && firstValue.Type != JTokenType.Null)
                {
                    this.First = ((int)firstValue);
                }
                JToken lastValue = inputObject["Last"];
                if (lastValue != null && lastValue.Type != JTokenType.Null)
                {
                    this.Last = ((int)lastValue);
                }
                JToken limitValue = inputObject["Limit"];
                if (limitValue != null && limitValue.Type != JTokenType.Null)
                {
                    this.Limit = ((int)limitValue);
                }
                JToken startValue = inputObject["Start"];
                if (startValue != null && startValue.Type != JTokenType.Null)
                {
                    this.Start = ((int)startValue);
                }
            }
        }
    }
}
