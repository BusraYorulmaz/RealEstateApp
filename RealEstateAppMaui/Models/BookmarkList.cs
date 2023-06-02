﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAppMaui.Models
{
    public class BookmarkList

    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]

        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("user_Id")]
        public int UserId { get; set; }

        [JsonProperty("propertyId")]
        public int PropertyId { get; set; }
    }
}
