/*
A class to dispatch our elevators to our floors.
Whenever somebody calls an elevator, the leastStopsDispatch service checks if an elevator is going to stop at the stop before dispatching an elevator.
*/

using DispatchStrategy;
using Elevator;

namespace ElevatorDispatchService;

public class LeastStopsDispatchService : IElevatorDispatchService
{
    private List<IElevator> _elevators = new();
    private IDispatchStrategy _strategy;

    public LeastStopsDispatchService(IDispatchStrategy dispatchStrategy)
    {
        _strategy = dispatchStrategy;
    }

    public void AddElevator(IElevator elevator)
    {
        _elevators.Add(elevator);
    }

    public bool RemoveElevator(IElevator elevator)
    {
        return _elevators.Remove(elevator);
    }

    public void Dispatch(int floor)
    {
        if (!_elevators.Any())
        {
            throw new Exception("Can't dispatch an elevator if there are no elevators.");
        }

        foreach (IElevator elevator in _elevators)
        {
            if (elevator.CheckIfExpectedStop(floor))
            {
                return;
            }
        }

        _strategy.Dispatch(floor, _elevators);
    }
}
