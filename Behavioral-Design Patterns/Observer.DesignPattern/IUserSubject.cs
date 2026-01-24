public interface IUserSubject
{
    void Attach(IUserObserver observer);
    void Detach(IUserObserver observer);
    void Notify(string message);
}
