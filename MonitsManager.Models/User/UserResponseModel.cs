using MonitsManager.Models.Error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MonitsManager.Models.User
{
    public class UserResponseModel
    {
        /// <summary>
        /// UserKey.
        /// </summary>
        [JsonProperty("user_key")]
        public Guid UserKey { get; set; }

        /// <summary>
        /// Name user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mail.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Document Number.
        /// </summary>
        [JsonProperty("document_number")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Document Type.
        /// </summary>
        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}
