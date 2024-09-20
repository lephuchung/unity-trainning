using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }
    public static string meteoriteOne = "Meteorite_1";
    public static string meteoriteTwo = "Meteorite_2";
    public static string meteoriteThree = "Meteorite_3";

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("Only 1 JunkSpawner is allowed to exist");
        JunkSpawner.instance = this;
    }
}
