public class UserSubjectObserver : IUserSubject
{
    private readonly List<IUserObserver> _observers;

    public UserSubjectObserver(List<IUserObserver> observers)
    {
        _observers = observers;
    }
    public void Attach(IUserObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IUserObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}
