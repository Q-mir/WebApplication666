namespace Service;

    //DATA -> EXECUTE -x RETURN -> EMPTY
public interface ICommand<in T> where T : class
{
    void Execute(T obj);
}

