/*
An implementation of the IElevatorFloorChoice interface.
It orders the elevator to go to the floors in chronological order.
*/

namespace ElevatorFloorChoice;

public class OldestFloorChoice : IElevatorFloorChoice
{
    public int ChooseNextFloor(IEnumerable<int> allFlours, int currentFloor)
    {
        if (!allFlours.Any())
        {
            return currentFloor;
        }
        return allFlours.ElementAt(0);
    }
}
