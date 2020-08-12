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
        allQuestion.Add(new Question()
        {
            question = "Which of these requirements make a password more secure ?",
            goodAnswer = new List<string>()
            {
                "special character",
                "more than 8 character length",
            },
            badAnswer = new List<string>()
            {
                "grandma firstname",
                "birthday year of Michael Jackson",
                "your favorite film"
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it makes a password harder to find.",
                "'#' is the correct answer because it makes a password harder to find.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 3,
        });
        allQuestion.Add(new Question()
        {
            question = "What the encryption is used for ?",
            goodAnswer = new List<string>()
            {
                "confidentiality",
                "integrity",
            },
            badAnswer = new List<string>()
            {
                "availability",
                "accessibilty",
                "authenticity"
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because encrytpion 'scramble' a message.",
                "'#' is the correct answer because a tampered encrypted message will result in a meaningless plaintext message.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 4,
        });
        allQuestion.Add(new Question()
        {
            question = "What hash functions are used for ?",
            goodAnswer = new List<string>()
            {
                "integrity",
            },
            badAnswer = new List<string>()
            {
                "availability",
                "accessibilty",
                "authenticity",
                "confidentiality",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because a tampered hashed message will result in a meaningless plaintext message.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 5,
        });
        allQuestion.Add(new Question()
        {
            question = "In which domain is a password useful ?",
            goodAnswer = new List<string>()
            {
                "confidentiality",
            },
            badAnswer = new List<string>()
            {
                "availability",
                "accessibilty",
                "authenticity",
                "integrity",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it prevent unauthorized access to confidential information.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 6,
        });
        allQuestion.Add(new Question()
        {
            question = "Which domain this definition refers to? 'preventing unauthorized disclosure of information. Includes secrecy, privacy' ?",
            goodAnswer = new List<string>()
            {
                "confidentiality",
            },
            badAnswer = new List<string>()
            {
                "availability",
                "accessibilty",
                "authenticity",
                "integrity",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it can prevent unauthorized disclosure information.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 7,
        });
        allQuestion.Add(new Question()
        {
            question = "Which domain this definition refers to? 'preventing unauthorized modification of data and system' ?",
            goodAnswer = new List<string>()
            {
                "integrity",
            },
            badAnswer = new List<string>()
            {
                "availability",
                "accessibilty",
                "authenticity",
                "confidentiality",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it makes sure that a message has not been falsified.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 8,
        });
        allQuestion.Add(new Question()
        {
            question = "Which domain this definition refers to? 'preventing downtime of systems or inability to access data/information' ?",
            goodAnswer = new List<string>()
            {
                "availability",
            },
            badAnswer = new List<string>()
            {
                "integrity",
                "accessibilty",
                "authenticity",
                "confidentiality",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because it makes sure that a system is always operational.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 9,
        });
        allQuestion.Add(new Question()
        {
            question = "Which of these methods confirm the truth of your identity ?",
            goodAnswer = new List<string>()
            {
                "password",
                "reCAPTCHA"
            },
            badAnswer = new List<string>()
            {
                "username",
                "encryption",
                "identity photo",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer because only you should know it.",
                "'#' is the correct answer because you demonstrate that you are not a robot.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 10,
        });
        allQuestion.Add(new Question()
        {
            question = "What is the definition of Authentication ?",
            goodAnswer = new List<string>()
            {
                "the process of confirming the truth or correctness of the claimed artefact or identity",
            },
            badAnswer = new List<string>()
            {
                "the process of granting permission to someone/thing do some action (e.g., access files)",
                "ability for parties to prove that a message has been sent by a specific person, and received by a specific person. Therefore neither party can claim they did not send/receive the message.",
                "protecting against forgery or tampering.",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 11,
        });
        allQuestion.Add(new Question()
        {
            question = "What is the definition of Authorization ?",
            goodAnswer = new List<string>()
            {
                "the process of granting permission to someone/thing do some action (e.g., access files)",
            },
            badAnswer = new List<string>()
            {
                "the process of confirming the truth or correctness of the claimed artefact or identity",
                "ability for parties to prove that a message has been sent by a specific person, and received by a specific person. Therefore neither party can claim they did not send/receive the message.",
                "protecting against forgery or tampering.",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 12,
        });
        allQuestion.Add(new Question()
        {
            question = "What is the definition of Non-repudiation ?",
            goodAnswer = new List<string>()
            {
                "ability for parties to prove that a message has been sent by a specific person, and received by a specific person. Therefore neither party can claim they did not send/receive the message.",
            },
            badAnswer = new List<string>()
            {
                "the process of granting permission to someone/thing do some action (e.g., access files)",
                "the process of confirming the truth or correctness of the claimed artefact or identity",
                "protecting against forgery or tampering.",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 13,
        });
        allQuestion.Add(new Question()
        {
            question = "What is the cyber security ?",
            goodAnswer = new List<string>()
            {
                "non-Information based assets that are vulnerable to threats via ICT",
            },
            badAnswer = new List<string>()
            {
                "information based assets Stored or transmitted using ICT",
                "the process of confirming the truth or correctness of the claimed artefact or identity",
                "information based assets Stored or transmitted using not ICT",
            },
            explanation = new List<string>()
            {
                "'#' is the cyber security.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 14,
        });
        allQuestion.Add(new Question()
        {
            question = "What is the information security ?",
            goodAnswer = new List<string>()
            {
                "information based assets Stored or transmitted using not ICT",
            },
            badAnswer = new List<string>()
            {
                "non-Information based assets that are vulnerable to threats via ICT",
                "information based assets Stored or transmitted using ICT",
                "the process of confirming the truth or correctness of the claimed artefact or identity",
            },
            explanation = new List<string>()
            {
                "'#' is the information security.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 15,
        });
        allQuestion.Add(new Question()
        {
            question = "What is the technology security ?",
            goodAnswer = new List<string>()
            {
                "information based assets Stored or transmitted using ICT",
            },
            badAnswer = new List<string>()
            {
                "information based assets Stored or transmitted using not ICT",
                "non-Information based assets that are vulnerable to threats via ICT",
                "the process of confirming the truth or correctness of the claimed artefact or identity",
            },
            explanation = new List<string>()
            {
                "'#' is the technology security.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 16,
        });
        allQuestion.Add(new Question()
        {
            question = "Which word is used to protect cyber environment, organization and user's assets ?",
            goodAnswer = new List<string>()
            {
                "collection of tool",
                "policies",
                "guidelines",
                "risk management approaches",
                "training"
            },
            badAnswer = new List<string>()
            {
                "connected computing devices",
                "infrastructure",
                "applications",
                "telecommunication system"
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, the other are used in a cyber environment but don't protect.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 17,
        });
        allQuestion.Add(new Question()
        {
            question = "Which word is used in a cyber environment by organization and user's assets ?",
            goodAnswer = new List<string>()
            {
                "connected computing devices",
                "infrastructure",
                "applications",
                "telecommunication system"
            },
            badAnswer = new List<string>()
            {
                "collection of tool",
                "policies",
                "guidelines",
                "risk management approaches",
                "training"
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, the other are used protect the cyber environment.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 18,
        });
    }
}