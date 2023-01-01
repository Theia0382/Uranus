namespace Uranus.Discord
{
	public class Emoji
	{
		public string? ID { get; init; }
		public string? Name { get; init; }
		public List<string>? Roles { get; init; }
		public User? User { get; init; }
		public bool? RequireColons { get; init; }
		public bool? Managed { get; init; }
		public bool? Animated { get; init; }
		public bool? Available { get; init; }
	}
}
