using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


//create new class to take in both a string and float to store name and time when submitting
[System.Serializable] public class Score
{
    public Score(string n, int r)
    {
        name = n;
        round = r;
    }
    public string name;
    public int round;
}
public class ScoreList : MonoBehaviour
{
    //create list to display name and time, taken from Score class
    public List<Score> scores = new List<Score>();

    public string fileName;
    public GameObject input;

    public GameObject finalPanel;
    public GameObject scorePanel;

    public GameObject entryPrefab;

    private int topScores = 0;
    private int maxScores = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        //check if file exist(has an entry been submitted)
        if (File.Exists(fileName))
        { 
            //read all entries in file (storing all score entries) until end of file
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (true)
                {
                        //if file has entries store values
                        try
                        {
                            string name = reader.ReadString();
                            int round = reader.ReadInt32();

                            //populate list with stored information from file
                            scores.Add(new Score(name, round));
                        }
                        //if no entries, break out of loop
                        catch (EndOfStreamException)
                        {
                            break;
                        }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scores.Sort(SortByScore);
    }
    //
    public void NewEntry()
    {
        //Get name input from input field
        string name = input.GetComponent<TMP_InputField>().text;
        //Get GameData Component 
        //Time-Get current time and subtract gamePlayStart
        int round = SpawnManager.waveNum;
        
        //create entry
        //insert at top of list
        scores.Insert(0, new Score(name, round));
        int offset = 50;
        Debug.Log(topScores);
        Debug.Log(scores[topScores]);

        //add score entry to score panel prefab
        foreach (Score score in scores)
        {
            GameObject temp = Instantiate(entryPrefab);
            Transform[] children = temp.GetComponentsInChildren<Transform>();
            children[1].GetComponent<TextMeshProUGUI>().text  =score.name;
            children[2].GetComponent<TextMeshProUGUI>().text = score.round.ToString();

            //placement of entry
            temp.transform.SetParent(scorePanel.transform);
            RectTransform rtrans = temp.GetComponent<RectTransform>();
            rtrans.anchorMin = new Vector2(0.5f, 0.5f);
            rtrans.anchorMax = new Vector2(0.5f, 0.5f);
            rtrans.pivot = new Vector2(0.5f, 0.5f);
            rtrans.localPosition = new Vector3(0, offset, 0);
            //move previous entry down by offset
            offset -= 35;

            
            
            topScores++;
        }

        finalPanel.SetActive(false);
        scorePanel.SetActive(true);
        

    }

    private void OnDestroy()
    {
        //open or create file(if first entry) and input scores into file 
        using (BinaryWriter write = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
        {
            foreach(Score score in scores)
            {
                write.Write(score.name);
                write.Write(score.round);
            }
        }
    }

    static int SortByScore(Score p1, Score p2)
    {
        return p2.round.CompareTo(p1.round);
    }
}
