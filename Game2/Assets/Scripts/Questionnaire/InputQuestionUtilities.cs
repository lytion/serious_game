using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputQuestionUtilities : MonoBehaviour
{
    private InitInputQuestion _initInputQuestion;
    public GameObject inputQuestionnaireMenu;
    public GameObject validateButton;
    public GameObject okButton;
    public GameObject inputResult;
    public GameObject inputAnswer;
    private List<Question> allQuestions;
    private string answer;
    private string _nextScene;

    public Question GetRandomQuestion()
    {
        allQuestions = _initInputQuestion.GetAllQuestions();
        int idx = new System.Random().Next(0, allQuestions.Count);
        return new Question{question = allQuestions[idx].question,
            goodAnswer = new List<string>(allQuestions[idx].goodAnswer), 
            badAnswer = new List<string>(allQuestions[idx].badAnswer)};
    }
    
    public void PrepareInputQuestion()
    {
        Question question = GetRandomQuestion();
        
        GameObject.Find("InputQuestion").GetComponent<TextMeshProUGUI>().text = question.question;
        answer = question.goodAnswer[0];
    }

    public void CheckAnswer()
    {
        string playerAnswer = GameObject.Find("InputAnswer").GetComponent<TMP_InputField>().text.ToLower();
        GameObject.Find("InputAnswer").GetComponent<TMP_InputField>().text = "";
        validateButton.SetActive(false);
        okButton.SetActive(true);
        inputResult.SetActive(true);
        inputAnswer.SetActive(false);
        if (Equals(answer, playerAnswer))
        {
            inputResult.GetComponentInChildren<TextMeshProUGUI>().text = "Answer correct !";
            HideInputQuestionnaireMenu();
            SceneManager.LoadScene(_nextScene);
        }
        else
        {
            inputResult.GetComponentInChildren<TextMeshProUGUI>().text = "The correct answer is: " + answer + ".";
        }

    }

    public void DisplayInputQuestionMenu()
    {
        Time.timeScale = 0;
        inputQuestionnaireMenu.SetActive(true);
        validateButton.SetActive(true);
        okButton.SetActive(false);
        inputResult.SetActive(false);
        inputAnswer.SetActive(true);
    }

    public void HideInputQuestionnaireMenu()
    {
        Time.timeScale = 1;
        inputQuestionnaireMenu.SetActive(false);
    }

    public void SetNextScene(string scene)
    {
        _nextScene = scene;
    }

    private void Start()
    {
        _initInputQuestion = GetComponent<InitInputQuestion>();
    }
}
