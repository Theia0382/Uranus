namespace Uranus.Discord.Builders
{
	public class SlashCommandOptionChoiceBuilder
	{
		public string? Name { get; set; }
		public Dictionary<string, string>? NameLocalizations { get; set; }
		public object? Value { get; set; }

		public SlashCommandOptionChoiceBuilder SetName( string name ) { Name = name; return this; }
		public SlashCommandOptionChoiceBuilder SetNameLocalizations( Dictionary<string, string> nameLocalizations ) { NameLocalizations = nameLocalizations; return this; }
		public SlashCommandOptionChoiceBuilder SetValue( object value ) { Value = value; return this; }

		public SlashCommandOptionChoiceProperties Build( )
		{
			SlashCommandOptionChoiceProperties properties = new( )
			{
				name = Name,
				name_localizations = NameLocalizations,
				value = Value
			};

			return properties;
		}
	}
}
