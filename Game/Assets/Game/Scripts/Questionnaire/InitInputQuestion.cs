using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInputQuestion : MonoBehaviour
{
    public static List<Question> allQuestion = new List<Question>();

    public List<Question> GetAllQuestions() { return allQuestion;}

    public void Start()
    {
        allQuestion.Add(new Question()
        {
            question = "What hash functions are used for ?",
            goodAnswer = new List<string>()
            {
                "integrity",
            },
            badAnswer = new List<string>()
        });
        allQuestion.Add(new Question()
        {
            question = "Which domain this definition refers to? “preventing unauthorized modification of data and system?",
            goodAnswer = new List<string>()
            {
                "integrity",
            },
            badAnswer = new List<string>()
        });
    }
}