using System;

public abstract class Events
{
    public static event Action StateChanged;
    public static event Action ApplicationStarted;
        
    public static event Action OpenUpdatePopup;
        

    public static void OnStateChanged()
    {
        StateChanged?.Invoke();
    }

    public static void OnApplicationStarted()
    {
        ApplicationStarted?.Invoke();
    }
}