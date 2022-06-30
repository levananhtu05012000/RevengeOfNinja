using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public GameData gameData;
    private string path = "";
    private string persistentPath = "";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        SetPaths();


        SaveData(new GameData());
        gameData = LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "GameData.json";

        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "GameData.json";

        //Debug.Log(path);
        //Debug.Log(persistentPath);
    }

    public void SaveData(GameData gd)
    {
        string savePath = path;
        string json = JsonUtility.ToJson(gd);

        using StreamWriter streamWriter = new StreamWriter(savePath);
        streamWriter.Write(json);

    }

    public GameData LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        GameData gameData = JsonUtility.FromJson<GameData>(json);
        return gameData;
    }
}
