using Uranus.Discord.Builders;
using Uranus.Discord;

namespace Uranus.Commands
{
	public class TestCommand : ICommand
	{
		public SlashCommandBuilder Data = new SlashCommandBuilder( )
			.SetName( "test" )
			.SetDescription( "command for test" )
			.AddStringOption( new SlashCommandOptionBuilder( )
				.SetName( "string" )
				.SetDescription( "option for test" ) );

		public async Task Execute( CommandInteraction interaction )
		{
			Console.WriteLine( "String: " + interaction.CommandData.GetOption( "string" ) );
		}

		SlashCommandBuilder ICommand.Data => Data;
	}
}
