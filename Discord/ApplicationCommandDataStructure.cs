namespace Uranus.Discord
{
	public struct ApplicationCommandDataStructure
	{
		public string id { get; set; }
		public string name { get; set; }
		public ApplicationCommandType type { get; set; }
		public ApplicationCommandDataOptionStructure[ ]? options { get; set; }
		public string? guild_id { get; set; }
		public string? target_id { get; set; }

		public CommandData Resolve( )
		{
			List<CommandDataOption>? Options = null;
			if ( options != null && options.Any( ) )
			{
				Options = new( );
				options.ToList( ).ForEach( delegate ( ApplicationCommandDataOptionStructure option )
				{
					Options.Add( option.Resolve( ) );
				} );
			}

			CommandData data = new( )
			{
				ID = id,
				Name = name,
				Type = type,
				Options = Options,
				GuildID = guild_id,
				TargetID = target_id
			};

			return data;
		}
	}
}
