using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public void PrepareQuestion()
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
        
        DisplayQuestion(question);
    }

    public void DisplayQuestion(Question question)
    {
        GameObject.Find("Question").GetComponent<TextMeshProUGUI>().text = question.question;
        int idx = new System.Random().Next(0, 4);
        List<TextMeshProUGUI> answers = new List<TextMeshProUGUI>();
        answers.Add(GameObject.Find("AnswerTextA").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextB").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextC").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextD").GetComponent<TextMeshProUGUI>());

        for (int i = 0; i < 4; i++)
        {
            if (i == idx)
                answers[i].text = question.goodAnswer[0];
            else
                answers[i].text = question.BadAnswer[(i > idx) ? i-1 : i];
        }
    }

    private void Start()
    {
        _initQuestion = GetComponent<InitQuestion>();
    }
}
