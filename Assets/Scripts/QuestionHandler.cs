using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO;

[System.Serializable]

public class QuestionHandler : MonoBehaviour
{
    private List<QuestionAnswer> easy;
    private List<QuestionAnswer> medium;
    private List<QuestionAnswer> hard;
    List<QuestionAnswer> qa;

    private QuestionLoader ql;
    public QuestionAnswer current;
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

    public string getCurrentAnswer()
    {
        return current.getAnswer();
    }


    public void loadQuestionSet(int qs)
    {
        switch (qs)
        {
            case 0:
                qa = easy;
                break;
            case 1:
                qa = medium;
                break;
            case 2:
                qa = hard;
                break;
        }
    }

    public void load(string set)
    {
        easy = loadFile(Application.dataPath + "/MathQ/Easy.txt");
        medium = loadFile(Application.dataPath + "/MathQ/Med.txt");
        hard = loadFile(Application.dataPath + "/MathQ/Hard.txt");
        qa = easy;
        loadQuestion();
    }

    private List<QuestionAnswer> loadFile(string path)
    {
        List<QuestionAnswer> qt = new List<QuestionAnswer>();
        string line;
        StreamReader file;
        file = new System.IO.StreamReader(path);
        while ((line = file.ReadLine()) != null)
        {
            string[] split = line.Split(',');
            qt.Add(new QuestionAnswer(split[0], split[1]));
        }
        return qt;
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

