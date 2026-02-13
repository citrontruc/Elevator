/*
An implementation of the IElevatorFloorChoice interface.
It privileggies the floor closest to the elevator currently.
*/

namespace ElevatorFloorChoice;

public class ClosestFloorChoice : IElevatorFloorChoice
{
    public int ChooseNextFloor(IEnumerable<int> allFlours, int currentFloor)
    {
        if (!allFlours.Any())
        {
            return currentFloor;
        }
        List<int> distanceToCurrentFloor = allFlours
            .Select(a => Math.Abs(a - currentFloor))
            .ToList();
        int closestFloorIndex = distanceToCurrentFloor.FindIndex(x =>
            x == distanceToCurrentFloor.Min()
        );
        return allFlours.ElementAt(closestFloorIndex);
    }
}
