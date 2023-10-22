using System;

public abstract class Events
{
    public static event Action StateChanged;
    public static event Action ApplicationStarted;
    public static event Action MenuStateChanged;
    public static event Action GameStateChanged;
    public static event Action CloseUpdatePopup;
    public static event Action OpenUpdatePopup;

    public static void OnStateChanged()
    {
        StateChanged?.Invoke();
    }

    public static void OnApplicationStarted()
    {
        ApplicationStarted?.Invoke();
    }

    public static void OnMenuStateChanged()
    {
        MenuStateChanged?.Invoke();
    }

    public static void OnGameStateChanged()
    {
        GameStateChanged?.Invoke();
    }

    public static void OnOpenUpdatePopup()
    {
        OpenUpdatePopup?.Invoke();
    }

    public static void OnCloseUpdatePopup()
    {
        CloseUpdatePopup?.Invoke();
    }
}