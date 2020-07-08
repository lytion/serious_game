using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUtilities : MonoBehaviour
{
    private InitQuestion _initQuestion;
    private List<Question> allQuestions;
    private int goodAnswer = -1;
    private List<TextMeshProUGUI> answers;
    public GameObject questionnaireMenu;

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
        goodAnswer = new System.Random().Next(0, 4);
        answers = new List<TextMeshProUGUI>();
        answers.Add(GameObject.Find("AnswerTextA").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextB").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextC").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextD").GetComponent<TextMeshProUGUI>());

        for (int i = 0; i < 4; i++)
        {
            ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            answers[i].transform.parent.GetComponent<Button>().colors = colors;
            
            if (i == goodAnswer)
                answers[i].text = question.goodAnswer[0];
            else
                answers[i].text = question.BadAnswer[(i > goodAnswer) ? i-1 : i];
        }
    }

    public void CheckAnswer(int selectedAnswer)
    {

        for (int i = 0; i < 4; i++)
        {
            if (i == goodAnswer)
            {
                ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                colors.normalColor = Color.green;
                colors.selectedColor = Color.green;
                answers[i].transform.parent.GetComponent<Button>().colors = colors;
            }
            else
            {
                ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                colors.normalColor = Color.red;
                colors.selectedColor = Color.red;
                answers[i].transform.parent.GetComponent<Button>().colors = colors;
            }
        }
    }
    
    public void DisplayQuestionnaireMenu()
    {
        Time.timeScale = 0;
        questionnaireMenu.SetActive(true);
    }

    public void HideQuestionnaireMenu()
    {
        questionnaireMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Start()
    {
        _initQuestion = GetComponent<InitQuestion>();
    }
}
