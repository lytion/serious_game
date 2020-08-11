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
    private string _explanationText;
    private int nbGoodAnswerInQuestion;
    private bool hasTookWrongAnswer;
    public GameObject questionnaireMenu;
    public GameObject validateButton;
    public GameObject okButton;
    public GameObject ExplanationContainer;
    private GameObject manager;
    private DropSystem _dropSystem;

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
            if (!a.hasAnswered)
            {
                _initQuestion.allQuestion[a.index].hasAnswered = true;
                questionIndex = a.index;
                return new Question{question = a.question,
                    goodAnswer = new List<string>(a.goodAnswer), 
                    badAnswer = new List<string>(a.badAnswer),
                    explanation = new List<string>(a.explanation),
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
                    explanation = new List<string>(a.explanation),
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
        if (manager.GetComponent<GameData>().GetIsTutorial())
            allQuestions = _initQuestion.GetTutorialQuestion();
        else
            allQuestions = _initQuestion.GetAllQuestions();
        allQuestions = allQuestions.OrderBy(x => Guid.NewGuid()).ToList();
        Question questionPicked;
        int nbQuestionAnswered = 0;
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
        hasTookWrongAnswer = false;
        nbGoodAnswerInQuestion = 1;
        
        int nbGoodAnswers = nbGoodAnswerInQuestion;
        for (int i = 0; i < 4; i++)
        {
            if (nbGoodAnswers > 0)
            {
                int idxGoodAnswer = new System.Random().Next(0, question.goodAnswer.Count);
                answersDict.Add(question.goodAnswer[idxGoodAnswer], true);
                _explanationText = question.explanation[idxGoodAnswer];
                _explanationText = _explanationText.Replace("#", question.goodAnswer[idxGoodAnswer]);
                ExplanationContainer.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text =
                    _explanationText;
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
            // ColorBlock colors = answers[idx].transform.parent.GetComponent<Button>().colors;
            // colors.normalColor = new Color32(24, 24, 24, 255);
            // colors.selectedColor = new Color32(70, 70, 70, 255);
            // colors.highlightedColor = new Color32(70, 70, 70, 255);
            // answers[idx].transform.parent.GetComponent<Button>().colors = colors;
            idx++;
        }
    }

    public void ButtonAnswerManager(int idxSelected)
    {
        if (selectedAnswers.Contains(idxSelected))
        {
            // ColorBlock colors = answers[idxSelected].transform.parent.GetComponent<Button>().colors;
            // colors.normalColor = new Color32(24, 24, 24, 255);
            // colors.selectedColor = new Color32(24, 24, 24, 255);
            // colors.highlightedColor = new Color32(70, 70, 70, 255);
            Color unpickedColor = new Color(0.09019608f, 0.09019608f, 0.09019608f);
            answers[idxSelected].transform.parent.parent.GetComponent<Image>().color = unpickedColor;
            // answers[idxSelected].transform.parent.GetComponent<Button>().colors = colors;
            
            selectedAnswers.Remove(idxSelected);
        }
        else
        {
            // ColorBlock colors = answers[idxSelected].transform.parent.GetComponent<Button>().colors;
            // colors.normalColor = new Color32(70, 70, 70, 255);
            // colors.selectedColor = new Color32(70, 70, 70, 255);
            // colors.highlightedColor = new Color32(24, 24, 24, 255);
            Color pickedColor = new Color(1f, 0.7803922f, 0.3411f);
            answers[idxSelected].transform.parent.parent.GetComponent<Image>().color = pickedColor;
            
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
                        Debug.Log(">>> idx: "+i+"answer: "+kvp.Key + "isCorrect: "+kvp.Value);
                    if (kvp.Value)
                    {
                        ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                        colors.normalColor = new Color32(11, 109, 11, 255);
                        colors.selectedColor = new Color32(11, 109, 11, 255);
                        colors.highlightedColor = new Color32(11, 109, 11, 255);
                        colors.disabledColor = new Color32(11, 109, 11, 255);
                        answers[i].transform.parent.GetComponent<Button>().colors = colors;
                        answers[i].transform.parent.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        if (selectedAnswers.Contains(i))
                        {
                            ColorBlock colors = answers[i].transform.parent.GetComponent<Button>().colors;
                            colors.normalColor = new Color32(143, 31, 31, 255);
                            colors.selectedColor = new Color32(143, 31, 31, 255);
                            colors.highlightedColor = new Color32(143, 31, 31, 255);
                            colors.disabledColor = new Color32(143, 31, 31, 255);
                            answers[i].transform.parent.GetComponent<Button>().colors = colors;
                            answers[i].transform.parent.GetComponent<Button>().interactable = false;
                            hasTookWrongAnswer = true;
                        }
                        else
                        {
                            answers[i].transform.parent.parent.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
        if (selectedAnswers.Count != 1)
            hasTookWrongAnswer = true;
        validateButton.SetActive(false);
        if (!hasTookWrongAnswer && selectedAnswers.Count == 1)
        {
            Debug.Log(">>> nbGoodAnswerInQuestion"+nbGoodAnswerInQuestion);
            Debug.Log(">>> nbGoodAnswerSelected"+hasTookWrongAnswer);
            if (_enemyType == "mob")
                _enemy.health -= manager.GetComponent<GameData>().GetPlayerAtk();
            else if (_enemyType == "chest")
                _chest.health -= manager.GetComponent<GameData>().GetPlayerAtk();
            _initQuestion.allQuestion[questionIndex].hasAnsweredCorrectly = true;
            okButton.SetActive(true);
        }
        else
        {
            if (_enemyType == "mob" && !manager.GetComponent<GameData>().GetIsTutorial())
                manager.GetComponent<GameData>().DecreasePlayerHealth(5);
            ExplanationContainer.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void DisplayQuestionnaireMenu()
    {
        Time.timeScale = 0;
        questionnaireMenu.SetActive(true);
        validateButton.SetActive(true);
        okButton.SetActive(false);
        ExplanationContainer.transform.GetChild(1).gameObject.SetActive(false);
        ExplanationContainer.transform.GetChild(0).gameObject.SetActive(false);
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
            
            Color unpickedColor = new Color(0.09019608f, 0.09019608f, 0.09019608f);
            answers[i].transform.parent.parent.GetComponent<Image>().color = unpickedColor;
            answers[i].transform.parent.parent.gameObject.SetActive(true);
        }
        
        if (!IsEndBattle() && !manager.GetComponent<GameData>().GetIsTutorial())
        {
            StartBattle();
        }
        else
        {
            if (_enemyType == "door")
            {
                GetComponent<DropSystem>().SetKeyFound(false);
                manager.GetComponent<GameData>().SetIsTutorial(false);
                SceneManager.LoadScene(_nextScene);
            }
            else if (_enemyType == "chest")
            {
                _dropSystem.DropItem(_dropSystem.GetAllChests());
            }
            else if (_enemyType == "boss")
            {
                GetComponent<DropSystem>().SetKeyFound(true);
            }
            if (manager.GetComponent<GameData>().GetPlayerHealth() <= 0)
            {
                if (SceneManager.GetActiveScene().name != "Intro1_boss")
                    manager.GetComponent<GameData>().SetPlayerAtk(5); 
                int hp = manager.GetComponent<GameData>().GetPlayerMaxHealth();
                manager.GetComponent<GameData>().SetPlayerHealth(hp);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // TODO Check who lose
            Destroy(_enemyObject);
        }
    }

    public void DisplayExplanation()
    {
        ExplanationContainer.transform.GetChild(1).gameObject.SetActive(false);
        ExplanationContainer.transform.GetChild(0).gameObject.SetActive(true);
        okButton.SetActive(true);
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
        if (manager.GetComponent<GameData>().GetIsTutorial() && _enemyType != "door")
            GameObject.Find("TutorialManager").GetComponent<Tutorial>().DisplayTutorialQuestion();
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
        Debug.Log(">>> hasTookWrongAnswer: "+hasTookWrongAnswer);
        if (_enemyType == "door" && hasTookWrongAnswer)
            return false;
        return true;
    }

    private void Start()
    {
        manager = GameObject.FindWithTag("GameManager");
        _initQuestion = GetComponent<InitQuestion>();
        _dropSystem = manager.GetComponent<DropSystem>();
    }
}
