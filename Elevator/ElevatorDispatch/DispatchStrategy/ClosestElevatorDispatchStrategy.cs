/*
An implementation of the IDispatchStrategy interface.
Privilege the elevator which is the closest to the floor of the User.
*/

using Elevator;

namespace DispatchStrategy;

public class ClosestElevatorDispatchStrategy : IDispatchStrategy
{
    public void Dispatch(int floor, IEnumerable<IElevator> elevators)
    {
        IElevator closestElevator = elevators.ElementAt(0);
        int minDistance = Math.Abs(floor - closestElevator.GetTargetFloor());

        for (int i = 1; i < elevators.Count(); i++)
        {
            IElevator currentElevator = elevators.ElementAt(i);
            if (minDistance > Math.Abs(floor - currentElevator.GetTargetFloor()))
            {
                closestElevator = currentElevator;
                minDistance = Math.Abs(floor - currentElevator.GetTargetFloor());
            }
        }

        closestElevator.AddStop(floor);
    }
}
