using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
public static class Leaderboard
{
    public static event Action OnLeaderboardChange;
    static List<Score> scores;

    public static List<Score> Scores{
        get{
            if (scores == null)
            {
                scores = Load();
            }
            return scores;
        }
    }
    public static void AddScore(string name, int value)
    {
        if (scores == null)
        {
            scores = Load();
        }

        scores.Add(new Score(name, value));

        scores = scores.OrderBy(x => x.value).Reverse().Take(10).ToList();

        Save();
        if(OnLeaderboardChange != null){
            OnLeaderboardChange.Invoke();
        }
    }

    public static void Clear(){
        scores = new List<Score>();
        Save();
    }

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.xggg";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoresData data = new ScoresData(scores.ToArray());
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static List<Score> Load()
    {
        string path = Application.persistentDataPath + "/save.xggg";
        if (File.Exists(path))
        {
            Debug.Log("File Exist");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ScoresData data = formatter.Deserialize(stream) as ScoresData;
            stream.Close();
            Debug.Log(data.data);
            return new List<Score>(data.data);
        }

        return new List<Score>();
    }


}

[System.Serializable]
public class Score
{
    public string name;
    public int value;

    public Score(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

}

[System.Serializable]
public class ScoresData
{
    public Score[] data;

    public ScoresData(Score[] data)
    {
        this.data = data;
    }
}