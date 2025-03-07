namespace BackendChallenge;

public class AdventureGame(List<Room> rooms)
{
    private ConsoleKeyInfo _lastKey;
    private int _playerLives;
    private Room _currentRoom = null!;
    
    public void Play()
    {
        Console.WriteLine("Welcome to the Adventure!");
        Console.WriteLine("Press any key to start or ESC to quit");

        _lastKey = Console.ReadKey(true);
        while (_lastKey.Key != ConsoleKey.Escape)
        {
            _currentRoom = PromptForRoom([.. rooms.Where(x => x.IsStart).Select(x => x.Id)]);
            _playerLives = 3;

            while (Continue())
            {
                _currentRoom.Display();
                var answer = _currentRoom.GetAnswer();

                Console.WriteLine(answer.Outcome);

                if (answer.LivesCost > 0)
                {
                    Console.WriteLine($"You lost {answer.LivesCost} lives");
                    _playerLives -= answer.LivesCost;
                    if (_playerLives <= 0)
                    {
                        break;
                    }
                    Console.WriteLine($"You have {_playerLives} lives left");
                }
                
                _currentRoom = answer.NextRoomId != 0 ? rooms.First(x => x.Id == answer.NextRoomId) : PromptForRoom(_currentRoom.AvailableRooms);
            }

            if (_lastKey.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(_playerLives > 0 ? "You won!" : "You died!");
                Console.WriteLine("Press any key to play again or Esc to quit");
                _lastKey = Console.ReadKey(true);
            }
        }    
        Console.WriteLine("Thank you for playing!");
    }

    Room PromptForRoom(List<int> availableRooms)
    {
        Console.WriteLine($"Choose a room {string.Join(",",availableRooms)} or Esc to quit");
        _lastKey = Console.ReadKey(intercept: true);
        while (true)
        {
            if (_lastKey.Key == ConsoleKey.Escape)
            {
                return rooms.First(x => x.IsExit);
            }

            if (int.TryParse(_lastKey.KeyChar.ToString(), out var roomId) && availableRooms.Contains(roomId))
            {
                return rooms.First(x => x.Id == roomId);
            }
        }
    }


    bool Continue()
    {
        return _lastKey.Key != ConsoleKey.Escape && _playerLives > 0 && !_currentRoom.IsExit;
    }
}