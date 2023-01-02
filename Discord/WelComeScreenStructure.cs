namespace Uranus.Discord
{
    public struct WelComeScreenStructure
    {
        public string? description { get; set; }
        public WelcomeScreenChannelStructure[] welcome_channels { get; set; }

        public WelcomeScreen Resolve()
        {
            List<WelcomeScreenChannel> WelcomeChannels = new();
            welcome_channels.ToList().ForEach(delegate (WelcomeScreenChannelStructure channel)
            {
                WelcomeChannels.Add(channel.Resolve());
            });

            WelcomeScreen screen = new()
            {
                Description = description,
                WelcomeChannels = WelcomeChannels
            };

            return screen;
        }
    }
}
