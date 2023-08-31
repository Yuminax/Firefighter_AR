using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Readjson : MonoBehaviour
{
    // JSON file
    public TextAsset json;

    // Data
    public string title;
    public string theme;
    public List<string> situations;
    public List<string> answer1;
    public List<string> answer2;
    public List<string> answer3;
    public List<int> correct;

    // Scene
    public GameManager gameManager;
    public Quizz quizzManager;

    [SerializeField] private TextMeshPro feedback;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.FindAnyObjectByType<GameManager>();
        quizzManager = Quizz.FindAnyObjectByType<Quizz>();

        //Situations
        //                                                            mapper (s<SitationList> = s.situation(string))
        situations = (List<string>)JSONReader.GetJSON(json).situations.Select(s => s.situation).ToList();

        //Answers
        answer1 = (List<string>)JSONReader.GetJSON(json).situations.Select(s => s.answers1).ToList();
        answer2 = (List<string>)JSONReader.GetJSON(json).situations.Select(s => s.answers2).ToList();
        answer3 = (List<string>)JSONReader.GetJSON(json).situations.Select(s => s.answers3).ToList();

        // Correct
        correct = (List<int>)JSONReader.GetJSON(json).situations.Select(s => s.correct).ToList();

        title = JSONReader.GetJSON(json).name;
        theme = JSONReader.GetJSON(json).theme;
    }

    public void AssignJSON()
    {
        feedback.text = "";
        gameManager.lastTouchedObject.GetComponent<Activity>().data = this;

        feedback.text = this.name + " a bien été selectionné";
    }
}

// read data from JSON data
public static class JSONReader
{
    public static JSONData GetJSON(TextAsset json)
    {
        JSONData jsonData = JsonUtility.FromJson<JSONData>(json.text);
        return jsonData;
    }
}

// Create variable connect with JSON data
[System.Serializable]
public class JSONData
{
    public int id;
    public string theme;
    public string name;
    public List<SituationsList> situations;
}

[System.Serializable]
public class SituationsList
{
    public int id;
    public string situation;
    public int correct;
    public string answers1;
    public string answers2;
    public string answers3;

}
