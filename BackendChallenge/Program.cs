using BackendChallenge;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var rooms = configuration.GetSection("rooms").Get<List<Room>>() ?? throw new Exception("No rooms found in configuration");

var adventureGame = new AdventureGame(rooms);
adventureGame.Play();
