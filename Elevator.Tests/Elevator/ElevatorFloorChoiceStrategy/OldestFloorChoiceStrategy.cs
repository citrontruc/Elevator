/*
Unit tests for the oldest floor choice strategy.
*/

using ElevatorFloorChoice;

namespace Elevator.Tests.ElevatorFloorChoiceStrategy;

public class OldestFloorChoiceUnitTest
{
    [Fact]
    public void ChooseNextFloor_WithNoFloors_ReturnsCurrentFloor()
    {
        // Arrange
        List<int> listFloors = new();
        int currentFloor = 2;
        OldestFloorChoice oldestFloorChoice = new();

        // Act
        int chosenFloor = oldestFloorChoice.ChooseNextFloor(listFloors, currentFloor);

        // Assert
        Assert.Equal(currentFloor, chosenFloor);
    }

    [Fact]
    public void ChooseNextFloor_WithFloors_ReturnsFirstValue()
    {
        // Arrange
        List<int> listFloors = new();
        listFloors.Add(10);
        listFloors.Add(7);
        listFloors.Add(3);
        int currentFloor = 2;
        OldestFloorChoice oldestFloorChoice = new();

        // Act
        int chosenFloor = oldestFloorChoice.ChooseNextFloor(listFloors, currentFloor);

        // Assert
        Assert.Equal(10, chosenFloor);
    }
}
