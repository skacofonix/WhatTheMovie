﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using WTM.RestApi.Client.Models;

namespace WTM.RestApi.Client.Models
{
    public partial class UserSearchResponse
    {
        private int? _displayCount;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? DisplayCount
        {
            get { return this._displayCount; }
            set { this._displayCount = value; }
        }
        
        private int? _displayMax;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? DisplayMax
        {
            get { return this._displayMax; }
            set { this._displayMax = value; }
        }
        
        private int? _displayMin;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? DisplayMin
        {
            get { return this._displayMin; }
            set { this._displayMin = value; }
        }
        
        private IList<IUserSummary> _items;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<IUserSummary> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }
        
        private int? _totalCount;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? TotalCount
        {
            get { return this._totalCount; }
            set { this._totalCount = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the UserSearchResponse class.
        /// </summary>
        public UserSearchResponse()
        {
            this.Items = new LazyList<IUserSummary>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken displayCountValue = inputObject["DisplayCount"];
                if (displayCountValue != null && displayCountValue.Type != JTokenType.Null)
                {
                    this.DisplayCount = ((int)displayCountValue);
                }
                JToken displayMaxValue = inputObject["DisplayMax"];
                if (displayMaxValue != null && displayMaxValue.Type != JTokenType.Null)
                {
                    this.DisplayMax = ((int)displayMaxValue);
                }
                JToken displayMinValue = inputObject["DisplayMin"];
                if (displayMinValue != null && displayMinValue.Type != JTokenType.Null)
                {
                    this.DisplayMin = ((int)displayMinValue);
                }
                JToken itemsSequence = ((JToken)inputObject["Items"]);
                if (itemsSequence != null && itemsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken itemsValue in ((JArray)itemsSequence))
                    {
                        IUserSummary iUserSummary = new IUserSummary();
                        iUserSummary.DeserializeJson(itemsValue);
                        this.Items.Add(iUserSummary);
                    }
                }
                JToken totalCountValue = inputObject["TotalCount"];
                if (totalCountValue != null && totalCountValue.Type != JTokenType.Null)
                {
                    this.TotalCount = ((int)totalCountValue);
                }
            }
        }
    }
}