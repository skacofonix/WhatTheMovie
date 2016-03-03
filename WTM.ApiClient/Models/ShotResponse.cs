﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WTM.ApiClient.Models
{
    public partial class ShotResponse
    {
        private string firstSolver;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string FirstSolver
        {
            get { return this.firstSolver; }
            set { this.firstSolver = value; }
        }
        
        private int? id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        private string image;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Image
        {
            get { return this.image; }
            set { this.image = value; }
        }
        
        private bool? isBookmarked;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsBookmarked
        {
            get { return this.isBookmarked; }
            set { this.isBookmarked = value; }
        }
        
        private bool? isFavourited;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsFavourited
        {
            get { return this.isFavourited; }
            set { this.isFavourited = value; }
        }
        
        private bool? isGore;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsGore
        {
            get { return this.isGore; }
            set { this.isGore = value; }
        }
        
        private bool? isNudity;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsNudity
        {
            get { return this.isNudity; }
            set { this.isNudity = value; }
        }
        
        private bool? isSolutionAvailable;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsSolutionAvailable
        {
            get { return this.isSolutionAvailable; }
            set { this.isSolutionAvailable = value; }
        }
        
        private bool? isVoteDeletation;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public bool? IsVoteDeletation
        {
            get { return this.isVoteDeletation; }
            set { this.isVoteDeletation = value; }
        }
        
        private IList<string> languages;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> Languages
        {
            get { return this.languages; }
            set { this.languages = value; }
        }
        
        private int? nbSolver;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? NbSolver
        {
            get { return this.nbSolver; }
            set { this.nbSolver = value; }
        }
        
        private int? numberOfDayBeforeSolution;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? NumberOfDayBeforeSolution
        {
            get { return this.numberOfDayBeforeSolution; }
            set { this.numberOfDayBeforeSolution = value; }
        }
        
        private int? numberOfFavourited;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? NumberOfFavourited
        {
            get { return this.numberOfFavourited; }
            set { this.numberOfFavourited = value; }
        }
        
        private string poster;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Poster
        {
            get { return this.poster; }
            set { this.poster = value; }
        }
        
        private DateTimeOffset? publidationDate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? PublidationDate
        {
            get { return this.publidationDate; }
            set { this.publidationDate = value; }
        }
        
        private IList<string> tags;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
        
        private string updater;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Updater
        {
            get { return this.updater; }
            set { this.updater = value; }
        }
        
        private string userStatus;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string UserStatus
        {
            get { return this.userStatus; }
            set { this.userStatus = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ShotResponse class.
        /// </summary>
        public ShotResponse()
        {
            this.Languages = new List<string>();
            this.Tags = new List<string>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken firstSolverValue = inputObject["FirstSolver"];
                if (firstSolverValue != null && firstSolverValue.Type != JTokenType.Null)
                {
                    this.FirstSolver = ((string)firstSolverValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken imageValue = inputObject["Image"];
                if (imageValue != null && imageValue.Type != JTokenType.Null)
                {
                    this.Image = ((string)imageValue);
                }
                JToken isBookmarkedValue = inputObject["IsBookmarked"];
                if (isBookmarkedValue != null && isBookmarkedValue.Type != JTokenType.Null)
                {
                    this.IsBookmarked = ((bool)isBookmarkedValue);
                }
                JToken isFavouritedValue = inputObject["IsFavourited"];
                if (isFavouritedValue != null && isFavouritedValue.Type != JTokenType.Null)
                {
                    this.IsFavourited = ((bool)isFavouritedValue);
                }
                JToken isGoreValue = inputObject["IsGore"];
                if (isGoreValue != null && isGoreValue.Type != JTokenType.Null)
                {
                    this.IsGore = ((bool)isGoreValue);
                }
                JToken isNudityValue = inputObject["IsNudity"];
                if (isNudityValue != null && isNudityValue.Type != JTokenType.Null)
                {
                    this.IsNudity = ((bool)isNudityValue);
                }
                JToken isSolutionAvailableValue = inputObject["IsSolutionAvailable"];
                if (isSolutionAvailableValue != null && isSolutionAvailableValue.Type != JTokenType.Null)
                {
                    this.IsSolutionAvailable = ((bool)isSolutionAvailableValue);
                }
                JToken isVoteDeletationValue = inputObject["IsVoteDeletation"];
                if (isVoteDeletationValue != null && isVoteDeletationValue.Type != JTokenType.Null)
                {
                    this.IsVoteDeletation = ((bool)isVoteDeletationValue);
                }
                JToken languagesSequence = ((JToken)inputObject["Languages"]);
                if (languagesSequence != null && languagesSequence.Type != JTokenType.Null)
                {
                    foreach (JToken languagesValue in ((JArray)languagesSequence))
                    {
                        this.Languages.Add(((string)languagesValue));
                    }
                }
                JToken nbSolverValue = inputObject["NbSolver"];
                if (nbSolverValue != null && nbSolverValue.Type != JTokenType.Null)
                {
                    this.NbSolver = ((int)nbSolverValue);
                }
                JToken numberOfDayBeforeSolutionValue = inputObject["NumberOfDayBeforeSolution"];
                if (numberOfDayBeforeSolutionValue != null && numberOfDayBeforeSolutionValue.Type != JTokenType.Null)
                {
                    this.NumberOfDayBeforeSolution = ((int)numberOfDayBeforeSolutionValue);
                }
                JToken numberOfFavouritedValue = inputObject["NumberOfFavourited"];
                if (numberOfFavouritedValue != null && numberOfFavouritedValue.Type != JTokenType.Null)
                {
                    this.NumberOfFavourited = ((int)numberOfFavouritedValue);
                }
                JToken posterValue = inputObject["Poster"];
                if (posterValue != null && posterValue.Type != JTokenType.Null)
                {
                    this.Poster = ((string)posterValue);
                }
                JToken publidationDateValue = inputObject["PublidationDate"];
                if (publidationDateValue != null && publidationDateValue.Type != JTokenType.Null)
                {
                    this.PublidationDate = ((DateTimeOffset)publidationDateValue);
                }
                JToken tagsSequence = ((JToken)inputObject["Tags"]);
                if (tagsSequence != null && tagsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken tagsValue in ((JArray)tagsSequence))
                    {
                        this.Tags.Add(((string)tagsValue));
                    }
                }
                JToken updaterValue = inputObject["Updater"];
                if (updaterValue != null && updaterValue.Type != JTokenType.Null)
                {
                    this.Updater = ((string)updaterValue);
                }
                JToken userStatusValue = inputObject["UserStatus"];
                if (userStatusValue != null && userStatusValue.Type != JTokenType.Null)
                {
                    this.UserStatus = ((string)userStatusValue);
                }
            }
        }
    }
}
