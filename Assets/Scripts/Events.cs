using System;

public abstract class Events
{
    public static event Action StateChanged;
    public static event Action ApplicationStarted;
    public static event Action MenuStateChanged;
    public static event Action InGameStateChanged;
    public static event Action LoseStateChanged;
    public static event Action WinStateChanged;
    public static event Action StartStateChanged;
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

    public static void OnInGameStateChanged()
    {
        InGameStateChanged?.Invoke();
    }
    
    public static void OnOpenUpdatePopup()
    {
        OpenUpdatePopup?.Invoke();
    }

    public static void OnCloseUpdatePopup()
    {
        CloseUpdatePopup?.Invoke();
    }

    public static void OnLoseStateChanged()
    {
        LoseStateChanged?.Invoke();
    }

    public static void OnWinStateChanged()
    {
        WinStateChanged?.Invoke();
    }

    public static void OnStartStateChanged()
    {
        StartStateChanged?.Invoke();
    }
}