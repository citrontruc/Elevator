/*
An implementation of the strategy pattern to handle different dispatch strategy for elevators.
*/

using Elevator;

namespace DispatchStrategy;

public interface IDispatchStrategy
{
    public void Dispatch(int floor, IEnumerable<IElevator> elevators);
}
