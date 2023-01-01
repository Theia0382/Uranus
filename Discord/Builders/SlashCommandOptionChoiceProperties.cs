namespace Uranus.Discord.Builders
{
	public struct SlashCommandOptionChoiceProperties
	{
		public string? name { get; set; }
		public Dictionary<string, string>? name_localizations { get; set; }
		public object? value { get; set; }

		/*
		public override string ToString( )
		{
			string str = "{";
			if ( name != null ) str += $@"""name"":""{name}"",";
			if ( name_localizations != null ) str += $@"""name_localizations"":{GetString( name_localizations )},";
			if ( value != null ) if ( value is string ) str += $@"""value"":""{value}"","; else str += $@"""value"":{value},";
			str = str.TrimEnd( ',' );
			str += "}";
			return str;
		}

		private static string? GetString( Dictionary<string, string>? dictionary )
		{
			if ( dictionary == null ) return null;
			var items = from item in dictionary select "\"" + item.Key + "\":\"" + item.Value + "\"";
			return "{" + string.Join( ",", items ) + "}";
		}
		*/
	}
}
