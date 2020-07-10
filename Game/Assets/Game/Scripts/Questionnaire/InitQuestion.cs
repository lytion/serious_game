using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitQuestion : MonoBehaviour
{
    public static List<Question> allQuestion = new List<Question>();

    public List<Question> GetAllQuestions() { return allQuestion;}

    public void Start()
    {
        allQuestion.Add(new Question()
        {
            question = "Which of these passwords is the more secure?",
            goodAnswer = new List<string>()
            {
                "dhsj4qk78ds",
                "prk8qwE1"
            },
            badAnswer = new List<string>()
            {
                "password1",
                "Garfield2004",
                "Th3B3$tP4$$w0rd",
                "qwerty012345"
            }
        });
        allQuestion.Add(new Question()
        {
            question = "Which of these passwords is the more secure and easiest to remember?",
            goodAnswer = new List<string>()
            {
                "Borris:Uk)2020",
                "kEnt:mSC#86"
            },
            badAnswer = new List<string>()
            {
                "Garfield2004",
                "dsjE8k)djsk45",
                "Th3B3$tP4$$w0rd",
                "qwerty012345"
            }
        });
    }
}