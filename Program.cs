using Uranus.Discord;
using Uranus.Discord.Builders;

namespace Uranus
{
	class Program
	{
		public static Task Main( string[ ] args ) => new Program( ).MainAsync( );

		public async Task MainAsync( )
		{
			Client client = new( Environment.GetEnvironmentVariable( "Token" ) );
			client.Ready += new Events.Ready( ).On;
			client.InteractionCreate += new Events.InteractionCreate( ).On;

			await client.LoginAsync( );
		}

		public static readonly List<ICommand> CommandList = new( )
		{
			new Commands.Ping( )
		};
	}

	public interface ICommand
	{
		SlashCommandBuilder Data { get; }
		Task Execute( CommandInteraction interaction );
	}
}