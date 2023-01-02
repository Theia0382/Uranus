using Uranus.Discord;
using Uranus.Discord.Builders;

namespace Uranus
{
	class Program
	{
		public static async Task Main( string[ ] args )
		{
			string? token = GetArgument( args, "token" );
			await new Program( ).MainAsync( token );
		}

		public async Task MainAsync( string? Token = null )
		{
			string token = Token ?? Environment.GetEnvironmentVariable( "Token" );
			Client client = new( token );
			client.Ready += new Events.Ready( ).On;
			client.InteractionCreate += new Events.InteractionCreate( ).On;

			await client.LoginAsync( );
		}

		public static readonly List<ICommand> CommandList = new( )
		{
			new Commands.Ping( )
		};

		private static string? GetArgument( string[ ] args, string name )
		{
			List<string> arguments = args.ToList( );
			int index = arguments.IndexOf( "--" + name );
			if ( index != -1 && index + 1 < arguments.Count )
			{
				if ( !arguments[ index + 1 ].StartsWith( "--" ) )
				{
					return arguments[ index + 1 ];
				}
			}
			return null;
		}
	}

	public interface ICommand
	{
		SlashCommandBuilder Data { get; }
		Task Execute( CommandInteraction interaction );
	}
}