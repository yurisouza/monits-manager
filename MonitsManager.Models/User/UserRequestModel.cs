using MonitsManager.Models.Error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MonitsManager.Models.User
{
    public class UserRequestModel
    {
        /// <summary>
        /// Name user.
        /// </summary>
        [Required(ErrorMessageResourceName = "NameUserRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string Name { get; set; }

        /// <summary>
        /// Mail.
        /// </summary>
        [Required(ErrorMessageResourceName = "MailUserRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string Mail { get; set; }

        /// <summary>
        /// Phone.
        /// </summary>
        [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string Phone { get; set; }

        /// <summary>
        /// Document Number.
        /// </summary>
        [JsonProperty("document_number")]
        [Required(ErrorMessageResourceName = "DocumentNumberRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Document Type.
        /// </summary>
        [JsonProperty("document_type")]
        [Required(ErrorMessageResourceName = "DocumentTypeRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string DocumentType { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string Password { get; set; }
    }
}
