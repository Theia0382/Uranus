using System.Collections.ObjectModel;

namespace Uranus.Discord
{
	public class CommandDataOption
	{
		public string Name { get; init; }
		public ApplicationCommandOptionType Type { get; init; }
		public object? Value { get; init; }
		public List<CommandDataOption>? Options { get; init; }
		public bool? Focused { get; init; }

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
	}
}
