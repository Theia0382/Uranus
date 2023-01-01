namespace Uranus.Discord.Builders
{
	public struct SlashCommandProperties
	{
		public string? name { get; set; }
		public Dictionary<string, string>? name_localizations { get; set; }
		public string? description { get; set; }
		public Dictionary<string, string>? description_localizations { get; set; }
		public SlashCommandOptionProperties[ ]? options { get; set; }
		public string? default_member_permissions { get; set; }
		public bool? dm_permission { get; set; }
		public ApplicationCommandType? type { get; set; }

		/*
		public override string ToString( )
		{
			string str = "{";
			if ( name != null ) str += $@"""name"":""{name}"",";
			if ( name_localizations != null ) str += $@"""name_localizations"":{GetString( name_localizations )},";
			if ( description != null ) str += $@"""description"":""{description}"",";
			if ( description_localizations != null ) str += $@"""description_localizations"":{GetString( description_localizations )},";
			if ( default_member_permissions != null ) str += $@"""default_member_permissions"":""{default_member_permissions}"",";
			if ( dm_permission != null ) str += $@"""dm_permission"":{GetString( dm_permission )},";
			if ( type != null ) str += $@"""type"":{type},";
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
		private static string? GetString( bool? boolean )
		{
			if ( boolean == true ) return "true";
			else if ( boolean == false ) return "false";
			else return null;
		}
		*/
	}
}
