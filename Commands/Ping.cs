using Uranus.Discord;
using Uranus.Discord.Builders;

namespace Uranus.Commands
{
	public class Ping : ICommand
	{
		SlashCommandBuilder ICommand.Data => new SlashCommandBuilder( )
			.SetName( "ping" )
			.SetDescription( "Replies with Pong!" );

		async Task ICommand.Execute( CommandInteraction interaction )
		{
			await interaction.DeferReplyAsync( );
			await Task.Delay( 3000 );
			await interaction.EditReplyAsync( "Pong!" );
		}
	}
}
