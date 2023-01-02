namespace Uranus.Discord
{
	public struct WelcomeScreenChannelStructure
	{
		public string channel_id { get; set; }
		public string description { get; set; }
		public string? emoji_id { get; set; }
		public string? emoji_name { get; set; }

		public WelcomeScreenChannel Resolve( )
		{
			WelcomeScreenChannel channel = new( )
			{
				ChannelID = channel_id,
				Description = description,
				EmojiID = emoji_id,
				EmojiName = emoji_name
			};

			return channel;
		}
	}
}
