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
    private List<TextMeshProUGUI> answers;
    Dictionary<string, bool> answersDict;
    private List<int> selectedAnswers;
    private int nbGoodAnswerInQuestion;
    private int nbGoodAnswerSelected;
    public GameObject questionnaireMenu;
    public GameObject validateButton;
    public GameObject okButton;
    private GameObject manager;
    private int _enemyHealth;

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
        selectedAnswers = new List<int>();
        nbGoodAnswerSelected = 0;
        nbGoodAnswerInQuestion = new System.Random().Next(1, (question.goodAnswer.Count) > 4 ? 4 : question.goodAnswer.Count+1);
        
        int nbGoodAnswers = nbGoodAnswerInQuestion;
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
        answers = new List<TextMeshProUGUI>();
        answers.Add(GameObject.Find("AnswerTextA").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextB").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextC").GetComponent<TextMeshProUGUI>());
        answers.Add(GameObject.Find("AnswerTextD").GetComponent<TextMeshProUGUI>());

        int idx = 0;
        foreach (KeyValuePair<string, bool> kvp in answersDict)
        {
            answers[idx].text = kvp.Key;
            idx++;
        }
    }

    public void ButtonAnswerManager(int idxSelected)
    {
        if (selectedAnswers.Contains(idxSelected))
        {
            ColorBlock colors = answers[idxSelected].transform.parent.GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            colors.highlightedColor = Color.white;
            answers[idxSelected].transform.parent.GetComponent<Button>().colors = colors;
            
            selectedAnswers.Remove(idxSelected);
        }
        else
        {
            ColorBlock colors = answers[idxSelected].transform.parent.GetComponent<Button>().colors;
            colors.normalColor = Color.cyan;
            colors.selectedColor = Color.cyan;
            colors.highlightedColor = Color.cyan;
            answers[idxSelected].transform.parent.GetComponent<Button>().colors = colors;
            
            selectedAnswers.Add(idxSelected);
        }
    }

    public void CheckAnswer()
    {
        for (int i = 0; i < 4; i++)
        {
            foreach (KeyValuePair<string, bool> kvp in answersDict)
            {
                if (answers[i].text == kvp.Key)
                {
                    if (selectedAnswers.Contains(i))
                        Debug.Log("idx: "+i+"answer: "+kvp.Key);
                    if (kvp.Value)
                    {
                        ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                        colors.normalColor = Color.green;
                        colors.selectedColor = Color.green;
                        colors.highlightedColor = Color.green;
                        answers[i].transform.parent.GetComponent<Button>().colors = colors;
                        if (selectedAnswers.Contains(i))
                            nbGoodAnswerSelected++;
                    }
                    else
                    {
                        ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                        colors.normalColor = Color.red;
                        colors.selectedColor = Color.red;
                        colors.highlightedColor = Color.red;
                        answers[i].transform.parent.GetComponent<Button>().colors = colors;
                    }
                }
            }
        }
        validateButton.SetActive(false);
        okButton.SetActive(true);
        
        if (nbGoodAnswerSelected == nbGoodAnswerInQuestion)
        {
            _enemyHealth -= 5;
            Debug.Log("YEEEEEEEES");
        }
        else
        {
            manager.GetComponent<GameData>().DecreasePlayerHealth(5);
        }
    }

    public void DisplayQuestionnaireMenu()
    {
        Time.timeScale = 0;
        questionnaireMenu.SetActive(true);
        validateButton.SetActive(true);
        okButton.SetActive(false);
    }

    public void HideQuestionnaireMenu()
    {
        questionnaireMenu.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < 4; i++)
        {
            ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            colors.highlightedColor = Color.white;
            answers[i].transform.parent.GetComponent<Button>().colors = colors;
        }
    }

    public void StartBattle(int enemyHealth)
    {
        _enemyHealth = enemyHealth;
        DisplayQuestionnaireMenu();
        PrepareQuestion();
        // while (_enemyHealth > 0 && manager.GetComponent<GameData>().GetPlayerHealth() > 0)
        // {
        //     DisplayQuestionnaireMenu();
        //     PrepareQuestion();
        // }
    }

    private void Start()
    {
        manager = GameObject.FindWithTag("GameManager");
        _initQuestion = GetComponent<InitQuestion>();
    }
}
