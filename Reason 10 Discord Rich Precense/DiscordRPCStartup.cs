using System;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.IO;
using DiscordRPC.Events;
using DiscordRPC.Exceptions;
using DiscordRPC.Message;
using DiscordRPC.Helper;

namespace Reason10DRP
{
    internal class DiscordRPCStartup
    {
		private static DiscordRpcClient client;

		public static void DRPCC()
        {
			client = new DiscordRpcClient("524248942465253416");

			//Set the logger
			client.Logger = new ConsoleLogger() { Level = LogLevel.Info };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				Details = "Example Project",
				State = "csharp example",
				Assets = new Assets()
				{
					LargeImageKey = "image_large",
					LargeImageText = "Reason Studios",
					SmallImageKey = "image_small"
				}
			});
		}
		public static void ExitDiscordRPC()
		{
			client.Dispose();
		}
	}
}