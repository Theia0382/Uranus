namespace Uranus.Discord
{
	public struct AttachmentStructure
	{
		public string id { get; set; }
		public string filename { get; set; }
		public string? description { get; set; }
		public string? content_type { get; set; }
		public ulong size { get; set; }
		public string url { get; set; }
		public string proxy_url { get; set; }
		public uint? height { get; set; }
		public uint? width { get; set; }
		public bool? ephemeral { get; set; }

		public Attachment Resolve( )
		{
			Attachment attachment = new( )
			{
				ID = id,
				FileName = filename,
				Description = description,
				ContentType = content_type,
				Size = size,
				URL = url,
				ProxyURL = proxy_url,
				Height = height,
				Width = width,
				Ephemeral = ephemeral
			};

			return attachment;
		}
	}
}
