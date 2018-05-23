using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnswer {
    private string question;
    private int answer;

   public string getQuestion()
    {
        return question;
    }

    public int getAnswer()
    {
        return answer;
    }

    public void setAnswer(int a)
    {
        answer = a;
    }

   public void setQuestion(string q)
    {
        question = q;
    }

    internal List<QuestionAnswer> toList()
    {
        throw new NotImplementedException();
    }
}
