using console_hero.Models.Items;

namespace console_hero;

public record Room(int X, int Y, int Width, int Height)
{
    public int CenterX =>  X + Width / 2;
    public int CenterY => Y + Height / 2;

    public bool IntersectsWith(Room other)
    {
        return X <= other.X + other.Width && X + Width >= other.X &&
               Y <= other.Y + other.Height && Y + Height >= other.Y;
    }

    public bool InsideOf(int x, int y)
    {
        return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
    }
}

public class DungeonBuilder : IDungeonStarter, IDungeonBuilder
{
    private Map? _map;
    private int _roomsToBuild = 0;
    private int _weaponsToAdd = 0;
    private int _itemsToAdd = 0;
    private int _goldToAdd = 0;
    private int _coinsToAdd = 0;
    private int _coinsDenomination = 0;
    private int _goldDenomination = 0;
    private int _centerRoomSize = 0;

    private static (int w, int h) _defaultMapSize = (41, 21);

    private bool _buildCorridors = false;
    private bool _buildCenterRoom = false;
    
    private readonly List<Room> _builtRooms = new List<Room>();

    private bool ValidateMap()
    {
        if (_map is null) throw new Exception("Map is null");
        return true;
    }
    private void ValidateSizeAndCreateMap(int? w, int? h)
    {
        if (w % 2 == 0) w--;
        if (h % 2 == 0) h--;
        if(w != null && h != null)
        {
            _map = new Map(w.Value, h.Value);
        }
        else
        {
            _map = new Map();
        }
    }
    
    private void BuildARoom(Room room)
    {
        for (int i = room.X; i < room.X + room.Width; i++)
        {
            for (int j = room.Y; j < room.Y + room.Height; j++)
            {
                if (i == room.X || i == room.X + room.Width - 1 ||
                    j == room.Y || j == room.Y + room.Height - 1)
                {
                    _map.Cells[i, j].IsWall = true;
                }
                else
                {
                    _map.Cells[i, j].IsWall = false;
                }
            }
        }
    }
    
    private int GetRandomOdd(Random rand, int min, int max)
    {
        int val = rand.Next(min, max);
        if (val % 2 == 0) val++; 
        if (val >= max) val -= 2;
        return val;
    }
    private int GetRandomEven(Random rand, int min, int max)
    {
        int val = rand.Next(min, max);
        if (val % 2 != 0) val++; 
        if (val >= max) val -= 2;
        return val;
    }
    
    private void BuildCenterRoom(int size)
    {
        if (size < 3) throw new ArgumentException("Center room size must be at least 3");
        
        size = Math.Min(size, Math.Min(_map.Width - 2, _map.Height - 2));
        if (size % 2 == 0) size--;

        int x = _map.Width / 2 - size / 2;
        int y = _map.Height / 2 - size / 2;
        if (x % 2 == 1) x--;
        if (y % 2 == 1) y--;
        

        Room room = new Room(x, y, size, size);
        BuildARoom(room);
        _builtRooms.Add(room);

    }
    private void BuildRooms(int rooms)
    {
        Random random = new Random();
        int maxAttempts = 100;
        int attempts = 0;
        int roomsBuilt = 0;

        while (roomsBuilt < rooms && attempts < maxAttempts)
        {
            int minw = 5;
            int minh = 5;
            int maxw = _map.Width / 2;
            int maxh = _map.Height / 2;
            maxw = Math.Max(minw, maxw);
            maxh = Math.Max(minh, maxh);
            
            int width = GetRandomOdd(random, minw, maxh);
            int height = GetRandomOdd(random, minh, maxh);
            int x = GetRandomEven(random,0, _map.Width - width);
            int y = GetRandomEven(random,0, _map.Height - height);
            
            Room room = new Room(x, y, width, height);
            bool overlaps = _builtRooms.Any(rm => rm.IntersectsWith(room));

            if (!overlaps)
            {
                BuildARoom(room);
                _builtRooms.Add(room);
                roomsBuilt++;
            }
            else attempts++;
        }

    }
    
    private void BuildCorridors()
    {
        bool[,] visited = new bool[_map!.Width, _map.Height];
        int[] dx = [0, 0, -2, 2];
        int[] dy = [-2, 2, 0, 0];
        Random random = new Random();

        
        for (int startY = 1; startY < _map.Height - 1; startY += 2)
        {
            for (int startX = 1; startX < _map.Width - 1; startX += 2)
            {
                
                if (!visited[startX, startY] && _map.Cells[startX, startY].IsWall)
                {
                    Stack<(int x, int y)> stack = new Stack<(int x, int y)>();
                    stack.Push((startX, startY));
                    visited[startX, startY] = true;
                    _map.Cells[startX, startY].IsWall = false;

                    while (stack.Count > 0)
                    {
                        (int x, int y) = stack.Peek();
                        List<int> validDirections = new List<int>();

                        for (int i = 0; i < dx.Length; i++)
                        {
                            int potentialX = x + dx[i];
                            int potentialY = y + dy[i];

                            if (potentialX >= 1 && potentialX <= _map.Width - 2 &&
                                potentialY >= 1 && potentialY <= _map.Height - 2 &&
                                !visited[potentialX, potentialY] &&
                                _map.Cells[potentialX, potentialY].IsWall)
                            {
                                validDirections.Add(i);
                            }
                        }

                        if (validDirections.Count > 0)
                        {
                            int r = random.Next(validDirections.Count);
                            int dirIndex = validDirections[r];

                            int newX = x + dx[dirIndex];
                            int newY = y + dy[dirIndex];
                            int wallX = x + (dx[dirIndex] / 2);
                            int wallY = y + (dy[dirIndex] / 2);

                            _map.Cells[wallX, wallY].IsWall = false;
                            _map.Cells[newX, newY].IsWall = false;

                            visited[newX, newY] = true;
                            stack.Push((newX, newY));
                        }
                        else
                        {
                            stack.Pop();
                        }
                    } 
                }
            }
        } 
    }
    private void ConnectRooms()
    {
        Random random = new Random();

        foreach (var room in _builtRooms)
        {
            List<(int x, int y)> potentialDoors = new List<(int x, int y)>();

            for (int x = room.X + 1; x < room.X + room.Width - 1; x++) 
            {
                if (room.Y - 1 > 0 && !_map!.Cells[x, room.Y - 1].IsWall)
                    potentialDoors.Add((x, room.Y));
            }

            for (int x = room.X + 1; x < room.X + room.Width - 1; x++)
            {
                int bottomY = room.Y + room.Height - 1;
                if (bottomY + 1 < _map!.Height - 1 && !_map.Cells[x, bottomY + 1].IsWall)
                    potentialDoors.Add((x, bottomY));
            }

            for (int y = room.Y + 1; y < room.Y + room.Height - 1; y++)
            {
                if (room.X - 1 > 0 && !_map!.Cells[room.X - 1, y].IsWall)
                    potentialDoors.Add((room.X, y));
            }

            for (int y = room.Y + 1; y < room.Y + room.Height - 1; y++)
            {
                int rightX = room.X + room.Width - 1;
                if (rightX + 1 < _map!.Width - 1 && !_map.Cells[rightX + 1, y].IsWall)
                    potentialDoors.Add((rightX, y));
            }

            if (potentialDoors.Count > 0)
            {
                potentialDoors = potentialDoors.OrderBy(d => random.Next()).ToList();
                
                int doorsToOpen = random.Next(1, 3); 
                
                for (int i = 0; i < Math.Min(doorsToOpen, potentialDoors.Count); i++)
                { 
                    _map!.Cells[potentialDoors[i].x, potentialDoors[i].y].IsWall = false;
                }
            }
        }
    }
    
    private void PlaceItemWherever(IItem item)
    {
        Random random = new Random();

        int x, y;
        do
        {
            x = random.Next(_map.Width);
            y = random.Next(_map.Height);
        } while (_map.Cells[x, y].IsWall);

        _map.Cells[x, y].Items.Push(item);
    }
    private void PlaceItemInARoom(IItem item, Room? room = null)
    {
        Random random = new Random();
        if (_builtRooms.Count == 0)
        {
            PlaceItemWherever(item);
            return;
        }
        if (room == null)
        {
            room = _builtRooms[random.Next(_builtRooms.Count)];
        }
        int x = 1 + room.X + random.Next(room.Width-1);
        int y = 1 + room.Y + random.Next(room.Height-1);
        _map.Cells[x, y].Items.Push(item);
    }
    
    private void PlaceWeapons(int weaponsToAdd)
    {
        Random random = new Random();
        if (_builtRooms.Count == 0)
        {
            for(int i = 0; i < weaponsToAdd; i++)
            {
                PlaceItemWherever(ItemGenerator.GenerateRandomWeapon());
            }
        }
        else
        {
            for (int i = 0; i < weaponsToAdd; i++)
            {
                PlaceItemInARoom(ItemGenerator.GenerateRandomWeapon());
            }
        }
    }
    private void PlaceItems(int itemsToAdd)
    {
        for (int i = 0; i < itemsToAdd; i++)
        {
            PlaceItemWherever(ItemGenerator.GenerateRandomItem());
        }
    }
    private void PlaceGold(int goldToAdd, int abundance)
    {
        Random random = new Random();
        
        for (int i = 0; i < goldToAdd; i++)
        {
            int value = random.Next(1, abundance);
            int chanceToBeInARoom = random.Next(100);
            if (chanceToBeInARoom < 90)
            {
                PlaceItemInARoom(new Gold(value));
                continue;
            }
            PlaceItemWherever(new Gold(value));
        }
    }
    private void PlaceCoins(int coinsToAdd, int abundance)
    {
        Random random = new Random();
        
        for (int i = 0; i < coinsToAdd; i++)
        {
            int value = random.Next(1, abundance);
            int chanceToBeInARoom = random.Next(100);
            if (chanceToBeInARoom < 60)
            {
                PlaceItemInARoom(new Coins(value));
                continue;
            }
            PlaceItemWherever(new Coins(value));
        }
    }
    private List<string> GenerateInstructions()
    {
        var instructionsList = new List<string>();

        instructionsList.Add(Instructions.GetInstruction(KeyActions.MoveUp));
        instructionsList.Add(Instructions.GetInstruction(KeyActions.MoveDown));
        instructionsList.Add(Instructions.GetInstruction(KeyActions.MoveLeft));
        instructionsList.Add(Instructions.GetInstruction(KeyActions.MoveRight));

        if (_itemsToAdd > 0)
        {
            instructionsList.Add(Instructions.GetInstruction(KeyActions.PickupItem));
            instructionsList.Add(Instructions.GetInstruction(KeyActions.DropItem));
        }

        if (_weaponsToAdd > 0)
        {
            instructionsList.Add(Instructions.GetInstruction(KeyActions.EquipItem));
        }

        return instructionsList;
    }
    
    public void Reset()
    {
        _map = new Map();
    }

    
    public IDungeonBuilder EmptyDungeon(int? w = null, int? h = null)
    {
        w ??= _defaultMapSize.w;
        h ??= _defaultMapSize.h;
        ValidateSizeAndCreateMap(w, h);
        w = _map.Width;
        h = _map.Height;
        for (int y = 0; y < h; y++ )
        {
            for (int x = 0; x < w; x++)
            {
                if (x == 0 || y == 0 || x == w - 1 || y == h - 1)
                    _map.Cells[x, y].IsWall = true;
                else
                    _map.Cells[x,y].IsWall = false;
            }
        }

        return this;
    }

    public IDungeonBuilder FullDungeon(int? w = null, int? h = null)
    {
        w ??= _defaultMapSize.w;
        h ??= _defaultMapSize.h;
        ValidateSizeAndCreateMap(w, h);
        foreach (var cell in _map.Cells)
        {
            cell.IsWall = true;
        }
        
        return this;
    }

    public IDungeonBuilder AddCorridors()
    {
        _buildCorridors = true;
        return this;
    }

    public IDungeonBuilder AddRooms(int rooms)
    {
        _roomsToBuild += rooms;
        return this;
    }

    public IDungeonBuilder AddCenterRoom(int size = 5)
    {
        _buildCenterRoom = true;
        _centerRoomSize = size;
        return this;
    }

    public IDungeonBuilder AddItems(int items)
    {
        _itemsToAdd += items;
        return this;
    }

    public IDungeonBuilder AddCoins(int coins, int denomination)
    {
        _coinsToAdd += coins;
        _coinsDenomination += denomination;
        return this;
    }

    public IDungeonBuilder AddGold(int gold, int denomination)
    {
        _goldToAdd += gold;
        _goldDenomination += denomination;
        return this;
    }

    public IDungeonBuilder AddWeapons(int weapons)
    {
        _weaponsToAdd += weapons;
        return this;
    }

    public Level Build()
    {
        ValidateMap();
        
        if (_buildCenterRoom) BuildCenterRoom(_centerRoomSize);
        if (_roomsToBuild > 0) BuildRooms(_roomsToBuild);

        if (_buildCorridors)
        {
            BuildCorridors();
            ConnectRooms();
        }

        if(_weaponsToAdd > 0) PlaceWeapons(_weaponsToAdd);
        if(_itemsToAdd > 0) PlaceItems(_itemsToAdd);
        if(_goldToAdd > 0) PlaceGold(_goldToAdd, _goldDenomination);
        if (_coinsToAdd > 0) PlaceCoins(_coinsToAdd, _coinsDenomination);

        Level level =  new Level(_map, GenerateInstructions());
        
        _buildCenterRoom = false;
        _roomsToBuild = 0;
        _buildCorridors = false;
        _weaponsToAdd = 0;
        _itemsToAdd = 0;
        _goldToAdd = 0;
        _coinsToAdd = 0;

        return level;
    }

}