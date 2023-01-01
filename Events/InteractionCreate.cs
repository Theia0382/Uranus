using Uranus.Discord;

namespace Uranus.Events
{
	public class InteractionCreate
	{
		public async Task On( BaseInteraction interaction )
		{
			Console.WriteLine( "Interaction Create" );

			if ( interaction is CommandInteraction )
			{
				OnCommand( ( CommandInteraction )interaction );
			}
		}

		public async Task OnCommand( CommandInteraction interaction )
		{
			Console.WriteLine( $"Command Interaction: {interaction.CommandData.Name}" );

			Program.CommandList
				.Find( command => command.Data.Name == interaction.CommandData.Name )?
				.Execute( interaction );
		}
	}
}
