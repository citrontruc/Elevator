/*
An interface to let an elevator choose the next floor from a list of floors.
*/

namespace ElevatorFloorChoice;

public interface IElevatorFloorChoice
{
    public int ChooseNextFloor(IEnumerable<int> allFlours, int currentFloor);
}
