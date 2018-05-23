using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnswer {
    private string question;
    private string answer;

    public QuestionAnswer(string q, string a)
    {
        question = q;
        answer = a;
    }

    public string getQuestion()
    {
        return question;
    }

    public string getAnswer()
    {
        return answer;
    }

    public void setAnswer(string a)
    {
        answer = a;
    }

   public void setQuestion(string q)
    {
        question = q;
    }


}
