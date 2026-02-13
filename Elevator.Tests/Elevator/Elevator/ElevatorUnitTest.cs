/*
Unit test to check the behaviour of our elevator.
*/

using ElevatorFloorChoice;

namespace Elevator.Tests.Elevator;

public class ElevatorUnitTest
{
    #region Floor handling
    [Fact]
    public void ElevatorWithOldestFloorStrategy_MovesBetweenFloorsInOrder_UntilAllRequestedFloorsAreVisited()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 0;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(0);
        List<int> listDemandedStops = new() { 5, 3, 6 };
        foreach (int floor in listDemandedStops)
        {
            elevator.AddStop(floor);
        }

        // Act
        List<int> listVisitedFloors = new();
        elevator.ChooseNextFloor();
        while (elevator.GetNumberStops() > 0)
        {
            bool reachedFloor = elevator.MoveToNextFloor();
            if (reachedFloor)
            {
                listVisitedFloors.Add(elevator.GetCurrentFloor());
            }
        }

        // Assert
        Assert.Equivalent(listVisitedFloors, listDemandedStops);
    }

    [Fact]
    public void ElevatorWithOldestFloorStrategy_MovesBetweenFloorsInOrderEvenWhenSuboptimal_UntilAllRequestedFloorsAreVisited()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 0;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(5);
        List<int> listDemandedStops = new() { 2, 7, 6, 1, 10 };
        foreach (int floor in listDemandedStops)
        {
            elevator.AddStop(floor);
        }

        // Act
        List<int> listVisitedFloors = new();
        elevator.ChooseNextFloor();
        while (elevator.GetNumberStops() > 0)
        {
            bool reachedFloor = elevator.MoveToNextFloor();
            if (reachedFloor)
            {
                listVisitedFloors.Add(elevator.GetCurrentFloor());
            }
        }

        // Assert
        Assert.Equivalent(listVisitedFloors, listDemandedStops);
    }

    [Fact]
    public async Task ElevatorWithOldestFloorStrategy_MovesBetweenFloorsInOrderAsyncEvenWhenSuboptimal_UntilAllRequestedFloorsAreVisited()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 0;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(5);
        List<int> listDemandedStops = new() { 2, 7, 6, 1, 10 };
        foreach (int floor in listDemandedStops)
        {
            elevator.AddStop(floor);
        }

        // Act
        List<int> listVisitedFloors = new();
        elevator.ChooseNextFloor();
        while (elevator.GetNumberStops() > 0)
        {
            bool reachedFloor = await elevator.MoveToNextFloorAsync();
            if (reachedFloor)
            {
                listVisitedFloors.Add(elevator.GetCurrentFloor());
            }
        }

        // Assert
        Assert.Equivalent(listVisitedFloors, listDemandedStops);
    }

    [Fact]
    public void ElevatorWithClosestFloorStrategy_MovesToClosestFloor_UntilAllRequestedFloorsAreVisited()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 0;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(0);
        List<int> listDemandedStops = new() { 5, 3, 6 };
        foreach (int floor in listDemandedStops)
        {
            elevator.AddStop(floor);
        }

        // Act
        List<int> listVisitedFloors = new();
        elevator.ChooseNextFloor();
        while (elevator.GetNumberStops() > 0)
        {
            bool reachedFloor = elevator.MoveToNextFloor();
            if (reachedFloor)
            {
                listVisitedFloors.Add(elevator.GetCurrentFloor());
            }
        }

        // Assert
        listDemandedStops.Sort();
        Assert.Equivalent(listVisitedFloors, listDemandedStops);
    }

    [Fact]
    public void ElevatorWithClosestFloorStrategy_MovesToClosestFloorWhenSuboptimal_UntilAllRequestedFloorsAreVisited()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 0;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(5);
        List<int> listDemandedStops = new() { 2, 7, 6, 1, 10 };
        List<int> optimalPath = new() { 6, 7, 10, 2, 1 };
        foreach (int floor in listDemandedStops)
        {
            elevator.AddStop(floor);
        }

        // Act
        List<int> listVisitedFloors = new();
        elevator.ChooseNextFloor();
        while (elevator.GetNumberStops() > 0)
        {
            bool reachedFloor = elevator.MoveToNextFloor();
            if (reachedFloor)
            {
                listVisitedFloors.Add(elevator.GetCurrentFloor());
            }
        }

        // Assert
        Assert.Equivalent(listVisitedFloors, optimalPath);
    }

    [Fact]
    public async Task ElevatorWithClosestFloorStrategy_MovesToClosestFloorAsync_UntilAllRequestedFloorsAreVisited()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 0;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(5);
        List<int> listDemandedStops = new() { 2, 7, 6, 1, 10 };
        List<int> optimalPath = new() { 6, 7, 10, 2, 1 };
        foreach (int floor in listDemandedStops)
        {
            elevator.AddStop(floor);
        }

        // Act
        List<int> listVisitedFloors = new();
        elevator.ChooseNextFloor();
        while (elevator.GetNumberStops() > 0)
        {
            bool reachedFloor = await elevator.MoveToNextFloorAsync();
            if (reachedFloor)
            {
                listVisitedFloors.Add(elevator.GetCurrentFloor());
            }
        }

        // Assert
        Assert.Equivalent(listVisitedFloors, optimalPath);
    }
    #endregion

    #region Passenger handling
    [Fact]
    public void Elevator_WhenTheFloorIsReached_OnlyConcernedPassengersDisembark()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 5;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);
        elevator.SetCurrentFloor(5);
        Passenger passengerFive = new() { RequestedFloor = 5 };
        Passenger passengerThree = new() { RequestedFloor = 3 };
        elevator.EmbarkPassengers(passengerFive);
        elevator.EmbarkPassengers(passengerFive);
        elevator.EmbarkPassengers(passengerThree);

        // Act
        elevator.DisembarkPassengers();

        // Assert
        Assert.Equal(1, elevator.GetNumberPassengers());
    }

    [Fact]
    public void Elevator_CanTakeNoMorePassengersThanCapacity()
    {
        // Arrange
        OldestFloorChoice oldestFloorChoice = new();
        int capacity = 5;
        ConcreteElevator elevator = new(oldestFloorChoice, capacity);

        // Act
        Passenger passenger = new() { RequestedFloor = 0 };
        List<bool> listAnswer = new();
        for (int i = 0; i < capacity; i++)
        {
            listAnswer.Add(elevator.EmbarkPassengers(passenger));
        }
        bool overCapacity = elevator.EmbarkPassengers(passenger);

        // Assert
        for (int i = 0; i < capacity; i++)
        {
            Assert.True(listAnswer[i]);
        }
        Assert.False(overCapacity);
    }
    #endregion
}
