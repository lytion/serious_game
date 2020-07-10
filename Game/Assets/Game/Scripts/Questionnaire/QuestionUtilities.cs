using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionUtilities : MonoBehaviour
{
    private InitQuestion _initQuestion;
    private List<Question> allQuestions;
    private int goodAnswer = -1;
    private List<TextMeshProUGUI> answers;
    Dictionary<string, bool> answersDict;
    public GameObject questionnaireMenu;

    public Question GetRandomQuestion()
    {
        allQuestions = _initQuestion.GetAllQuestions();
        int idx = new System.Random().Next(0, allQuestions.Count);
        return new Question{question = allQuestions[idx].question,
            goodAnswer = new List<string>(allQuestions[idx].goodAnswer), 
            badAnswer = new List<string>(allQuestions[idx].badAnswer)};
    }

    void ShuffleAnswers()
    {
        System.Random rand = new System.Random();
        answersDict = answersDict.OrderBy(x => rand.Next())
            .ToDictionary(item => item.Key, item => item.Value);

    }

    public void PrepareQuestion()
    {
        Question question = GetRandomQuestion();
        answersDict = new Dictionary<string, bool>();
        
        int nbGoodAnswers = new System.Random().Next(1, (question.goodAnswer.Count) > 4 ? 4 : question.goodAnswer.Count+1);
        for (int i = 0; i < 4; i++)
        {
            if (nbGoodAnswers > 0)
            {
                int idxGoodAnswer = new System.Random().Next(0, question.goodAnswer.Count);
                answersDict.Add(question.goodAnswer[idxGoodAnswer], true);
                question.goodAnswer.RemoveAt(idxGoodAnswer);
                nbGoodAnswers--;
            }
            else
            {
                int idxBadAnswer = new System.Random().Next(0, question.badAnswer.Count);
                answersDict.Add(question.badAnswer[idxBadAnswer], false);
                question.badAnswer.RemoveAt(idxBadAnswer);
            }
        }

        ShuffleAnswers();
        DisplayQuestion(question.question);
    }

    public void DisplayQuestion(string question)
    {
        GameObject.Find("Question").GetComponent<TextMeshProUGUI>().text = question;
        goodAnswer = new System.Random().Next(0, 4);
        answers = new List<TextMeshProUGUI>();
        answers.Add(GameObject.Find("AnswerTextA").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextB").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextC").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextD").GetComponent<TextMeshProUGUI>());

        int idx = 0;
        foreach (KeyValuePair<string, bool> kvp in answersDict)
        {
            ColorBlock colors = answers[idx].transform.parent.GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            answers[idx].transform.parent.GetComponent<Button>().colors = colors;
            
            answers[idx].text = kvp.Key;
            idx++;
        }
    }

    public void CheckAnswer(int selectedAnswer)
    {
        for (int i = 0; i < 4; i++)
        {
            foreach (KeyValuePair<string, bool> kvp in answersDict)
            {
                if (answers[i].text == kvp.Key)
                {
                    if (kvp.Value)
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
