/*
An implementation of the IDispatchStrategy interface.
Privilege the elevator which has the smallest numbers of stops.
*/

using Elevator;

namespace DispatchStrategy;

public class ElevatorWithLeastFloorStrategy : IDispatchStrategy
{
    public void Dispatch(int floor, IEnumerable<IElevator> elevators)
    {
        IElevator leastStopElevator = elevators.ElementAt(0);
        int minStop = leastStopElevator.GetNumberStops();

        for (int i = 1; i < elevators.Count(); i++)
        {
            IElevator currentElevator = elevators.ElementAt(i);
            if (minStop > currentElevator.GetNumberStops())
            {
                leastStopElevator = currentElevator;
                minStop = currentElevator.GetNumberStops();
            }
        }

        leastStopElevator.AddStop(floor);
    }
}
