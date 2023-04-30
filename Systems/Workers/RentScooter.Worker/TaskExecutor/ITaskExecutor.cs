namespace RentScooter.Worker;

public interface ITaskExecutor
{
    void Start();
    void StartRent();
    void StopRent();
}
