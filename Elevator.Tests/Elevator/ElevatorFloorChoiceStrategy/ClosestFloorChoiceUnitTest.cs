/*
Unit tests for the closest floor choice strategy.
*/

using ElevatorFloorChoice;

namespace Elevator.Tests.ElevatorFloorChoiceStrategy;

public class ClosestFloorChoiceUnitTest
{
    [Fact]
    public void ChooseNextFloor_WithNoFloors_ReturnsCurrentFloor()
    {
        // Arrange
        List<int> listFloors = new();
        int currentFloor = 2;
        ClosestFloorChoice closestFloorChoice = new();

        // Act
        int chosenFloor = closestFloorChoice.ChooseNextFloor(listFloors, currentFloor);

        // Assert
        Assert.Equal(currentFloor, chosenFloor);
    }

    [Fact]
    public void ChooseNextFloor_WithFloorsUp_ReturnsClosestFloor()
    {
        // Arrange
        List<int> listFloors = new();
        listFloors.Add(10);
        listFloors.Add(7);
        listFloors.Add(3);
        int currentFloor = 2;
        ClosestFloorChoice closestFloorChoice = new();

        // Act
        int chosenFloor = closestFloorChoice.ChooseNextFloor(listFloors, currentFloor);

        // Assert
        Assert.Equal(3, chosenFloor);
    }

    [Fact]
    public void ChooseNextFloor_WithFloorsDown_ReturnsClosestFloor()
    {
        // Arrange
        List<int> listFloors = new();
        listFloors.Add(10);
        listFloors.Add(7);
        listFloors.Add(6);
        listFloors.Add(7);
        listFloors.Add(1);
        int currentFloor = 2;
        ClosestFloorChoice closestFloorChoice = new();

        // Act
        int chosenFloor = closestFloorChoice.ChooseNextFloor(listFloors, currentFloor);

        // Assert
        Assert.Equal(1, chosenFloor);
    }
}
