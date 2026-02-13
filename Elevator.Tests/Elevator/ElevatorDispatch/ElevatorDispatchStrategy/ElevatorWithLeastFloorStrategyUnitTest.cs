/*
Evaluation of the Elevator With least floors strategy.
*/

using DispatchStrategy;
using ElevatorFloorChoice;

namespace Elevator.Tests.ElevatorDispatchStrategy;

public class ElevatorWithLeastFloorStrategyUnitTest
{
    public IElevator GetOldestFloorChoiceElevator()
    {
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 5;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        return elevator;
    }

    [Fact]
    public void ElevatorWithLeastFloorDispatchStrategy_ChoosesElevatorWithLeastExpectedStops()
    {
        // Arrange
        List<IElevator> listElevators = new();
        listElevators.Add(GetOldestFloorChoiceElevator());
        listElevators.Add(GetOldestFloorChoiceElevator());
        listElevators.ElementAt(0).SetCurrentFloor(3);
        listElevators.ElementAt(0).SetTargetFloor(3);
        listElevators.ElementAt(0).AddStop(1);
        listElevators.ElementAt(0).AddStop(2);

        ElevatorWithLeastFloorStrategy strategy = new();

        // Act
        strategy.Dispatch(4, listElevators);

        // Assert
        Assert.Equal(2, listElevators.ElementAt(0).GetNumberStops());
        Assert.Equal(1, listElevators.ElementAt(1).GetNumberStops());
    }
}
