using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionUtilities : MonoBehaviour
{
    private InitQuestion _initQuestion;
    private List<Question> allQuestions;
    private int questionIndex;
    private List<TextMeshProUGUI> answers;
    Dictionary<string, bool> answersDict;
    private List<int> selectedAnswers;
    private int nbGoodAnswerInQuestion;
    private int nbGoodAnswerSelected;
    public GameObject questionnaireMenu;
    public GameObject validateButton;
    public GameObject okButton;
    private GameObject manager;

    private string _enemyType;
    private Goal _door;
    private chest _chest;
    private mobs _enemy;
    private GameObject _enemyObject;
    private string _nextScene;

    public Question FindQuestion()
    {
        foreach (var a in allQuestions)
        {
            Debug.Log(a.question);
            if (!a.hasAnswered)
            {
                _initQuestion.allQuestion[a.index].hasAnswered = true;
                questionIndex = a.index;
                return new Question{question = a.question,
                    goodAnswer = new List<string>(a.goodAnswer), 
                    badAnswer = new List<string>(a.badAnswer),
                    hasAnsweredCorrectly = false,
                    hasAnswered = false,
                };
            }
        }

        return GetNonCorrectAnsweredQuestion();
    }

    public Question GetNonCorrectAnsweredQuestion()
    {
        foreach (var a in allQuestions)
        {
            if (a.hasAnswered && !a.hasAnsweredCorrectly)
            {
                _initQuestion.allQuestion[a.index].hasAnswered = true;
                questionIndex = a.index;
                return new Question{question = a.question,
                    goodAnswer = new List<string>(a.goodAnswer), 
                    badAnswer = new List<string>(a.badAnswer),
                    hasAnsweredCorrectly = false,
                    hasAnswered = false,
                };
            }
        }

        return null;
    }

    public void ResetAnsweredQuestion()
    {
        bool nonCorrectAnswer = false;
        Debug.Log(">>> All questions have been answered...");
        foreach (var a in allQuestions)
        {
            if (a.hasAnswered && !a.hasAnsweredCorrectly)
            {
                nonCorrectAnswer = true;
                _initQuestion.allQuestion[a.index].hasAnswered = false;
                Debug.Log(">>> Questions reset!");
            }
        }

        if (!nonCorrectAnswer)
        {
            Debug.Log(">>> All questions have been correctly answered...");
            foreach (var a in allQuestions)
            {
                _initQuestion.allQuestion[a.index].hasAnswered = false;
                _initQuestion.allQuestion[a.index].hasAnsweredCorrectly = false;
            }
            Debug.Log(">>> All questions have been reset!");
        }
    }
    
    public Question GetRandomQuestion()
    {
        allQuestions = _initQuestion.GetAllQuestions();
        allQuestions = allQuestions.OrderBy(x => Guid.NewGuid()).ToList();
        Question questionPicked;
        int nbQuestionAnswered = 0;
        Debug.Log("initquestion");
        foreach (var a in _initQuestion.GetAllQuestions())
        {
            Debug.Log(a.question);
        }
        Debug.Log("allQuestions");
        questionPicked = FindQuestion();
        if (questionPicked == null)
        {
            ResetAnsweredQuestion();
            questionPicked = FindQuestion();
        }
        
        return questionPicked;
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
            colors.normalColor = new Color32(24, 24, 24, 255);
            colors.selectedColor = new Color32(24, 24, 24, 255);
            colors.highlightedColor = new Color32(70, 70, 70, 255);
            answers[idxSelected].transform.parent.GetComponent<Button>().colors = colors;
            
            selectedAnswers.Remove(idxSelected);
        }
        else
        {
            ColorBlock colors = answers[idxSelected].transform.parent.GetComponent<Button>().colors;
            colors.normalColor = new Color32(70, 70, 70, 255);
            colors.selectedColor = new Color32(70, 70, 70, 255);
            colors.highlightedColor = new Color32(24, 24, 24, 255);
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
                        colors.normalColor = new Color32(41, 158, 41, 255);
                        colors.selectedColor = new Color32(41, 158, 41, 255);
                        colors.highlightedColor = new Color32(41, 158, 41, 255);
                        colors.disabledColor = new Color32(41, 158, 41, 255);
                        answers[i].transform.parent.GetComponent<Button>().colors = colors;
                        answers[i].transform.parent.GetComponent<Button>().interactable = false;
                        if (selectedAnswers.Contains(i))
                            nbGoodAnswerSelected++;
                    }
                    else
                    {
                        ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                        colors.normalColor = new Color32(143, 31, 31, 255);
                        colors.selectedColor = new Color32(143, 31, 31, 255);
                        colors.highlightedColor = new Color32(143, 31, 31, 255);
                        colors.disabledColor = new Color32(143, 31, 31, 255);
                        answers[i].transform.parent.GetComponent<Button>().colors = colors;
                        answers[i].transform.parent.GetComponent<Button>().interactable = false;
                    }
                }
            }
        }
        validateButton.SetActive(false);
        okButton.SetActive(true);
        
        if (nbGoodAnswerSelected == nbGoodAnswerInQuestion)
        {
            if (_enemyType == "mob")
                _enemy.health -= 5;
            else if (_enemyType == "chest")
                _chest.health -= 5;
            _initQuestion.allQuestion[questionIndex].hasAnsweredCorrectly = true;
            Debug.Log("YEEEEEEEES");
        }
        else
        {
            if (_enemyType == "mob")
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
            colors.normalColor = new Color32(24, 24, 24, 255);
            colors.selectedColor = new Color32(70, 70, 70, 255);
            colors.highlightedColor = new Color32(70, 70, 70, 255);
            answers[i].transform.parent.GetComponent<Button>().colors = colors;
            answers[i].transform.parent.GetComponent<Button>().interactable = true;
        }
        
        if (!IsEndBattle())
        {
            StartBattle();
        }
        else
        {
            if (_enemyType == "door")
                SceneManager.LoadScene(_nextScene);
            // TODO Check who lose
            Destroy(_enemyObject);
        }
    }

    public void SetEnemyType(string type)
    {
        _enemyType = type;
    }

    public void SetEnemy(mobs mob, GameObject mobObject)
    {
        _enemy = mob;
        _enemyObject = mobObject;
    }

    public void SetChest(chest chest, GameObject chestObject)
    {
        _chest = chest;
        _enemyObject = chestObject;
    }
    
    public void SetNextScene(string scene)
    {
        _nextScene = scene;
    }

    public void StartBattle()
    {
        DisplayQuestionnaireMenu();
        PrepareQuestion();
    }

    public bool IsEndBattle()
    {
        if (_enemyType == "mob" && _enemy != null && _enemy.health > 0 && 
            manager.GetComponent<GameData>().GetPlayerHealth() > 0)
            return false;
        if (_enemyType == "chest" && _chest != null && _chest.health > 0)
            return false;
        if (_enemyType == "door" && nbGoodAnswerSelected != nbGoodAnswerInQuestion)
            return false;
        return true;
    }

    private void Start()
    {
        manager = GameObject.FindWithTag("GameManager");
        _initQuestion = GetComponent<InitQuestion>();
    }
}
