using Uranus.Discord;

namespace Uranus.Events
{
	public class Ready
	{
		public async Task On( Client client )
		{
			Console.WriteLine( $"Ready! Logged in as {client.User.Name}#{client.User.Discriminator}" );
		}
	}
}
