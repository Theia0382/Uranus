namespace Uranus.Discord
{
	public class CommandData
	{
		public string ID { get; init; }
		public string Name { get; init; }
		public ApplicationCommandType Type { get; init; }
		public List<CommandDataOption>? Options { get; init; }
		public string? GuildID { get; init; }
		public string? TargetID { get; init; }

		public object? GetOption( string name )
		{
			return Options?.Find( option => option.Name == name )?.Value;
		}
		public CommandDataOption? GetSubCommand( string name )
		{
			CommandDataOption? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option != null && option.Type == ApplicationCommandOptionType.SubCommand )
				{
					value = option;
				}
			} );

			return value;
		}
		public CommandDataOption? GetSubCommandGroup( string name )
		{
			CommandDataOption? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option != null && option.Type == ApplicationCommandOptionType.SubCommandGroup )
				{
					value = option;
				}
			} );

			return value;
		}
		public string? GetStringOption( string name )
		{
			string? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.String )
				{
					value = option.Value as string;
				}
			} );

			return value;
		}
		public long? GetIntegerOption( string name )
		{
			long? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Integer )
				{
					value = option.Value as long?;
				}
			} );

			return value;
		}
		public bool? GetBooleanOption( string name )
		{
			bool? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Boolean )
				{
					value = option.Value as bool?;
				}
			} );

			return value;
		}
		public string? GetUserOption( string name )
		{
			string? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.User )
				{
					value = option.Value.ToString( );
				}
			} );

			return value;
		}
		public string? GetChannelOption( string name )
		{
			string? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Channel )
				{
					value = option.Value.ToString( );
				}
			} );

			return value;
		}
		public string? GetRoleOption( string name )
		{
			string? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Role )
				{
					value = option.Value.ToString( );
				}
			} );

			return value;
		}
		public string? GetMentionableOption( string name )
		{
			string? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Mentionable )
				{
					value = option.Value.ToString( );
				}
			} );

			return value;
		}
		public double? GetNumberOption( string name )
		{
			double? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Number )
				{
					value = option.Value as double?;
				}
			} );

			return value;
		}
		public Attachment? GetAttachmentOption( string name )
		{
			Attachment? value = null;
			Options?.FindAll( option => option.Name == name ).ForEach( delegate ( CommandDataOption option )
			{
				if ( option.Value != null && option.Type == ApplicationCommandOptionType.Attachment )
				{
					value = ( option.Value as AttachmentStructure? )?.Solve( );
				}
			} );

			return value;
		}

	}
}
