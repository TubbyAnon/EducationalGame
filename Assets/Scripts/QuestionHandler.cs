using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class QuestionHandler : MonoBehaviour
{
    private List<QuestionAnswer> qa;
    private QuestionLoader ql;
    private QuestionAnswer current;
    private string path;


    public void Awake()
    {
        path = Application.dataPath + "/MathQ/";
    }

    public void loadQuestion()
    {
        current = qa[0];    
        qa.RemoveAt(0);
    }

    public string getCurrentQuestion()
    {
        return current.getQuestion();
    }

    public int getCurrentAnswer()
    {
        return current.getAnswer();
    }
    public void load(string set)
    {
        switch(set)
        {
            case "addition":
                path = path + "Addition.json";
                Debug.Log(path);
                break;
        }
        List<QuestionAnswer> list = new List<QuestionAnswer>();
        list = JsonUtility.FromJson<List<QuestionAnswer>>(path);
        list.Shuffle();
        qa = list;
        loadQuestion();
    }
}

//code from:
//https://stackoverflow.com/questions/273313/randomize-a-listt
static class Extensions
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

