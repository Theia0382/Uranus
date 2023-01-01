using Uranus.Discord;
using Uranus.Discord.Builders;

namespace Uranus
{
	class Program
	{
		public static Task Main( string[ ] args ) => MainAsync( );

		public static Client client = new( Environment.GetEnvironmentVariable( "Token" ) );

		public static async Task MainAsync( )
		{
			Config.Set( ); // Set Token Environment
			await SetEvents( );

			await client.Login( );
		}

		private static async Task SetEvents( )
		{
			client.Ready += new Events.Ready( ).On;
			client.InteractionCreate += new Events.InteractionCreate( ).On;
		}

		public static readonly List<ICommand> CommandList = new( )
		{
			new Commands.Ping( ),
			new Commands.TestCommand( )
		};
	}

	public interface ICommand
	{
		SlashCommandBuilder Data { get; }
		Task Execute( CommandInteraction interaction );
	}
}