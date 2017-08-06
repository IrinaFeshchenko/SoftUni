using System;
using System.Text;

public class Clinic
{
    private Pet[] rooms;
    private string name;
    private int numberOfRooms;

    public Clinic(string name, int numberOfRooms)
    {
        this.Name = name;
        this.NumberOfRooms = numberOfRooms;
        this.FirstIndex = this.NumberOfRooms / 2;
        this.OccupiedRooms = 0;
        this.rooms = new Pet[this.NumberOfRooms];
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (value.Length < 1 || value.Length > 100)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.name = value;
        }
    }

    private int NumberOfRooms
    {
        get => this.numberOfRooms;
        set
        {
            if (value < 1 || value > 101 || value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.numberOfRooms = value;
        }
    }
    private int FirstIndex { get; set; }
    private int OccupiedRooms { get; set; }
    public Pet[] Rooms
    {
        get => this.rooms;
        private set => this.rooms = value;
    }

    public bool AddPet(Pet pet)
    {
        if (this.OccupiedRooms >= this.NumberOfRooms)
        {
            return false;
        }

        this.rooms[this.GetFirstFreeRoomForAccomodation()] = pet;
        this.OccupiedRooms++;
        return true;
    }

    public bool Release()
    {
        if (this.OccupiedRooms == 0)
        {
            return false;
        }

        this.rooms[this.GetFirstOccupiedRoomForRelease()] = null;
        this.OccupiedRooms--;
        return true;
    }

    public bool HasEmptyRooms()
    {
        return this.NumberOfRooms > this.OccupiedRooms;
    }

    private int GetFirstFreeRoomForAccomodation()
    {
        int currentIindex = this.FirstIndex;
        int previousIndex = this.FirstIndex;

        for (int i = 0; i < this.NumberOfRooms; i++)
        {
            if (i > 0)
            {
                int corrector = (i % 2 == 1) ? -1 : 1;
                currentIindex = previousIndex + i * corrector;
                previousIndex = currentIindex;
            }

            if (this.rooms[currentIindex] == null)
            {
                return currentIindex;
            }
        }

        throw new Exception("Clinic is full!");
    }

    private int GetFirstOccupiedRoomForRelease()
    {
        for (int i = this.FirstIndex; i < this.NumberOfRooms; i++)
        {
            if (this.rooms[i] != null)
            {
                return i;
            }
        }

        for (int i = 0; i < this.FirstIndex; i++)
        {
            if (this.rooms[i] != null)
            {
                return i;
            }
        }

        throw new Exception("Clinic is empty!");
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < this.NumberOfRooms; i++)
        {
            sb.AppendLine(this.rooms[i]?.ToString() ?? "Room empty");
        }

        return sb.ToString();
    }
}