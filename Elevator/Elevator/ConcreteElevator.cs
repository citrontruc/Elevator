/*
A concrete implementation of the elevator interface.
*/

using ElevatorFloorChoice;

namespace Elevator;

public class ConcreteElevator : IElevator
{
    #region Floor properties
    private ElevatorDirection _elevatorDirection = ElevatorDirection.StandStill;
    private int _currentFloor = 0;
    private int _targetFloor = 0;
    private List<int> _listFloors = new();
    private IElevatorFloorChoice _floorChoiceStrategy;
    #endregion

    #region Passenger properties
    private int _capacity;
    private int _numPassengers => _passengers.Count;
    private List<Passenger> _passengers = new();
    #endregion

    #region Constructor
    public ConcreteElevator(IElevatorFloorChoice floorChoiceStrategy, int capacity)
    {
        _floorChoiceStrategy = floorChoiceStrategy;
        _capacity = capacity;
    }
    #endregion

    #region Getters and Setters
    public ElevatorDirection GetStatus()
    {
        return _elevatorDirection;
    }

    public int GetCurrentFloor()
    {
        return _currentFloor;
    }

    public int GetTargetFloor()
    {
        return _targetFloor;
    }

    public int GetNumberStops()
    {
        return _listFloors.Count;
    }

    public int GetNumberPassengers()
    {
        return _numPassengers;
    }

    public void SetCurrentFloor(int floor)
    {
        _currentFloor = floor;
    }

    public void AddStop(int floorValue)
    {
        _listFloors.Add(floorValue);
    }

    private void RemoveStop(int floorValue)
    {
        _listFloors.Remove(floorValue);
    }
    #endregion

    #region Handle floors
    private void UpdateStatus()
    {
        switch (_currentFloor.CompareTo(_targetFloor))
        {
            case < 0:
                _elevatorDirection = ElevatorDirection.Up;
                break;
            case > 0:
                _elevatorDirection = ElevatorDirection.Down;
                break;
            case 0:
                _elevatorDirection = ElevatorDirection.StandStill;
                break;
        }
    }

    public void ChooseNextFloor()
    {
        _targetFloor = _floorChoiceStrategy.ChooseNextFloor(_listFloors, _currentFloor);
        UpdateStatus();
    }

    public bool MoveToNextFloor()
    {
        UpdateStatus();
        switch (_elevatorDirection)
        {
            case ElevatorDirection.Up:
                _currentFloor++;
                break;
            case ElevatorDirection.Down:
                _currentFloor--;
                break;
            case ElevatorDirection.StandStill:
                RemoveStop(_currentFloor);
                ChooseNextFloor();
                return true;
            default:
                break;
        }
        return false;
    }

    public async Task<bool> MoveToNextFloorAsync()
    {
        while (_currentFloor != _targetFloor)
        {
            switch (_elevatorDirection)
            {
                case ElevatorDirection.Up:
                    _currentFloor++;
                    break;
                case ElevatorDirection.Down:
                    _currentFloor--;
                    break;
                case ElevatorDirection.StandStill:
                    break;
                default:
                    break;
            }
            await Task.Delay(100);
        }
        RemoveStop(_currentFloor);
        ChooseNextFloor();
        return true;
    }
    #endregion

    #region Handle passengers
    public bool EmbarkPassengers(Passenger passenger)
    {
        if (_capacity > _numPassengers)
        {
            _passengers.Add(passenger);
            AddStop(passenger.RequestedFloor);
            return true;
        }
        return false;
    }

    public void DisembarkPassengers()
    {
        _passengers.RemoveAll(x => x.RequestedFloor == _currentFloor);
    }
    #endregion
}
