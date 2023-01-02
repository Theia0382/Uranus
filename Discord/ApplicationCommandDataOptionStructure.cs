namespace Uranus.Discord
{
	public struct ApplicationCommandDataOptionStructure
	{
		public string name { get; set; }
		public ApplicationCommandOptionType type { get; set; }
		public object? value { get; set; }
		public ApplicationCommandDataOptionStructure[ ]? options { get; set; }
		public bool? focused { get; set; }

		public CommandDataOption Resolve( )
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

			CommandDataOption option = new( )
			{
				Name = name,
				Type = type,
				Value = value,
				Options = Options,
				Focused = focused
			};

			return option;
		}
	}
}
