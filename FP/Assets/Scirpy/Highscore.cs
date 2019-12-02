using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
    private GameObject tower;
    private Transform container;
    private Transform template;
    private List<HighscoreEntry> highscoreEntryList;
    private Highscores highscores;
    private List<Transform> highscoreEntryTransformList;

    // Use this for initialization

    private void Awake()
    {
        container = transform.Find("Container");
        template = container.Find("HighscoreTemp");

        template.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("highscoretable"))
        {
            Debug.Log("Has playerPref");
            onPlayerPref();
        }

        if (!PlayerPrefs.HasKey("highscoretable"))
        {
            Debug.Log("None playerPref");
            onNewGame();
        }
            
        
        
        GameObject scoreHolder = GameObject.Find("ScoreHolder");
        Score scoreHolderScript = scoreHolder.GetComponent<Score>();
        Debug.Log("score: " + scoreHolderScript.getScore());
        if(scoreHolderScript.getDone() == true)
        {
            addHighscoreEntry(scoreHolderScript.getScore(), System.DateTime.Now.ToString());
            scoreHolderScript.setDone(false);
            scoreHolderScript.setScore(-1);
            onPlayerPref();
        } 

    }

    void onNewGame()
    {
        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry {score = 0, name = "None" },
            new HighscoreEntry {score = 0, name = "None" },
            new HighscoreEntry {score = 0, name = "None" },
            //new HighscoreEntry {score = 0, name = "None" },
        };

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighscoreEntry temp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = temp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, container, highscoreEntryTransformList);
        }

        highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoretable", json);
        PlayerPrefs.Save();
    }

    void onPlayerPref()
    {
        string jsonString = PlayerPrefs.GetString("highscoretable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry temp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = temp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, container, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHigh = 0.6f;
        Transform entryTransform = Instantiate(template, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHigh * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;

        }

        int score = highscoreEntry.score;
        string name = highscoreEntry.name;

        entryTransform.Find("ScoreTxt").GetComponent<Text>().text = score.ToString();
        entryTransform.Find("NameTxt").GetComponent<Text>().text = name;
        entryTransform.Find("PositionTxt").GetComponent<Text>().text = rankString;

        transformList.Add(entryTransform);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    public void addHighscoreEntry(int nscore, string nname)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry
        {
            score = nscore,
            name = nname
        };

        string jsonString = PlayerPrefs.GetString("highscoretable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoretable", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;

    }
}
