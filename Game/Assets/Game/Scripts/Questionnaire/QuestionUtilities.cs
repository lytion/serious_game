using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionUtilities : MonoBehaviour
{
    private InitQuestion _initQuestion;
    private List<Question> allQuestions;
    
    public Question GetRandomQuestion()
    {
        allQuestions = _initQuestion.GetAllQuestions();
        int idx = new System.Random().Next(0, allQuestions.Count);
        return allQuestions[idx];
    }

    public Question PrepareQuestion()
    {
        Question question = GetRandomQuestion();
        
        int idxGoodAnswer = new System.Random().Next(0, question.goodAnswer.Count);
        question.goodAnswer = new List<string>() {question.goodAnswer[idxGoodAnswer]};
        
        List<string> badAnswer = new List<string>();
        for (int i = 0; i < 3; i++)
        {
            int idxBadAnswer = new System.Random().Next(0, question.BadAnswer.Count);
            badAnswer.Add(question.BadAnswer[idxBadAnswer]);
            question.BadAnswer.RemoveAt(idxBadAnswer);
        }
        question.BadAnswer = badAnswer;
        
        return question;
    }

    private void Start()
    {
        _initQuestion = GetComponent<InitQuestion>();
    }
}
