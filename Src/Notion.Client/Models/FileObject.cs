﻿using System;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UploadedFile), "file")]
    [JsonSubtypes.KnownSubType(typeof(ExternalFile), "external")]
    public abstract class FileObject : IPageIcon
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }
    }

    public class UploadedFile : FileObject
    {
        public override string Type => "file";

        [JsonProperty("file")]
        public Info File { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("expiry_time")]
            public DateTime ExpiryTime { get; set; }
        }
    }

    public class ExternalFile : FileObject
    {
        public override string Type => "external";

        [JsonProperty("external")]
        public Info External { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
