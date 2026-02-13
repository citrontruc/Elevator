/*
An interface for our elevator.
*/

namespace Elevator;

public interface IElevator
{
    #region Constructor
    public ElevatorDirection GetStatus();
    #endregion

    #region Getters and Setters
    public int GetCurrentFloor();
    public int GetTargetFloor();
    public int GetNumberStops();
    public int GetNumberPassengers();
    public void SetCurrentFloor(int floor);
    public void SetTargetFloor(int floor);
    public bool CheckIfExpectedStop(int floor);
    public void AddStop(int floorValue);
    #endregion

    #region Passengers handling
    public bool EmbarkPassengers(Passenger passenger);
    public void DisembarkPassengers();
    #endregion

    #region Floor Handling
    public void ChooseNextFloor();
    public bool MoveToNextFloor();
    public Task<bool> MoveToNextFloorAsync();
    #endregion
}
