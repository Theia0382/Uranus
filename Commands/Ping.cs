using Uranus.Discord;
using Uranus.Discord.Builders;

namespace Uranus.Commands
{
	public class Ping : ICommand
	{
		public SlashCommandBuilder Data = new SlashCommandBuilder( )
			.SetName( "ping" )
			.SetDescription( "Replies with Pong!" );

		public async Task Execute( CommandInteraction interaction )
		{
			await interaction.DeferReply( );
			await Task.Delay( 3000 );
			await interaction.EditReply( "Pong!" );
		}

		SlashCommandBuilder ICommand.Data => Data;
	}
}
