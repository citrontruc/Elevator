using Elevator;
using ElevatorFloorChoice;

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
while (elevator.GetNumberStops() > 0)
{
    bool reachedFloor = elevator.MoveToNextFloor();
    Console.WriteLine($"CurrentFloor {elevator.GetCurrentFloor()}");
    Console.WriteLine($"TargetFloor {elevator.GetTargetFloor()}");
    await Task.Delay(100);
    if (reachedFloor)
    {
        listVisitedFloors.Add(elevator.GetCurrentFloor());
    }
}

foreach (int floor in listVisitedFloors)
{
    Console.WriteLine(floor);
}
