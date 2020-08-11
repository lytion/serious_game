using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitQuestion : MonoBehaviour
{
    public List<Question> allQuestion = new List<Question>();
    public List<Question> tutorialQuestion = new List<Question>();

    public List<Question> GetAllQuestions() { return allQuestion;}
    public List<Question> GetTutorialQuestion() { return tutorialQuestion;}

    public void Start()
    {
        tutorialQuestion.Add(new Question()
        {
            question = "Pick one answer. The correct answer wil turn in green otherwise it will turn in red.",
            goodAnswer = new List<string>()
            {
                "Good Answer",
            },
            badAnswer = new List<string>()
            {
                "  Bad Answer",
                " Bad Answer ",
                "Bad Answer  ",
            },
            explanation = new List<string>()
            {
                "You're lucky this is a tutorial but next time you will lose health !",
                "You're lucky this is a tutorial but next time you will lose health !",
                "You're lucky this is a tutorial but next time you will lose health !",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 0,
        });
        // All questions
        allQuestion.Add(new Question()
        {
            question = "Which of these passwords is the more secure?",
            goodAnswer = new List<string>()
            {
                "dHsj4_k78ds",
                "prk8q&wE1"
            },
            badAnswer = new List<string>()
            {
                "password1",
                "Garfield2004",
                "Th3B3$tP4$$w0rd",
                "qwerty012345"
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it has more than 8 characters length, has lower and upper case, digits and special characters",
                "'#' is the correct answer because it has more than 8 characters length, has lower and upper case, digits and special characters",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 0,
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
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it has more than 8 characters length, has lower and upper case, digits and special characters" +
                "but also because it contains some word that is easy to remember.",
                "'#' is the correct answer because it has more than 8 characters length, has lower and upper case, digits and special characters" +
                "but also because it contains some word that is easy to remember.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 1,
        });
        allQuestion.Add(new Question()
        {
            question = "Which of these passwords is weak?",
            goodAnswer = new List<string>()
            {
                "myOwlHedw1ge",
                "admin",
                "PeteR99",
                "B7s0"
            },
            badAnswer = new List<string>()
            {
                "kEnt:mSC#86",
                "dsjE8k)djsk45",
                "7C4kE-mm3&_E"
            },
            explanation = new List<string>()
            {
              "'#' is the correct answer because it can be found easily by searching information about you on social network ofr example.",
              "'#' is the correct answer because it is one of the password hackers try first.",
              "'#' is the correct answer because it can be found easily by searching information about you on social network ofr example.",
              "'#' is the correct answer because the length of the password is too short and can be found easily by a brute force attack."
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 2,
        });
    }
}