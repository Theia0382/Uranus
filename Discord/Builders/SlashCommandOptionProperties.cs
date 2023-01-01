namespace Uranus.Discord.Builders
{
	public struct SlashCommandOptionProperties
	{
		public ApplicationCommandOptionType? type { get; set; }
		public string? name { get; set; }
		public Dictionary<string, string>? name_localizations { get; set; }
		public string? description { get; set; }
		public Dictionary<string, string>? description_localizations { get; set; }
		public bool? required { get; set; }
		public SlashCommandOptionChoiceProperties[ ]? choices { get; set; }
		public SlashCommandOptionProperties[ ]? options { get; set; }
		public ChannelType[ ]? channel_types { get; set; }
		public object? min_value { get; set; }
		public object? max_value { get; set; }
		public ushort? min_length { get; set; }
		public ushort? max_length { get; set; }
		public bool? autocomplete { get; set; }
	}
}
