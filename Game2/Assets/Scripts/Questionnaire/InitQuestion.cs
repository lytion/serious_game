using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitQuestion : MonoBehaviour
{
    public List<Question> allQuestion = new List<Question>();
    public List<Question> tutorialQuestion = new List<Question>();
    public List<Question> mapQuestion2 = new List<Question>();
    public List<Question> mapQuestion3 = new List<Question>();
    
    public List<Question> GetAllQuestions() { return allQuestion;}
    public List<Question> GetTutorialQuestion() { return tutorialQuestion;}
    public List<Question> GetMapQuestion2() { return mapQuestion2;}
    public List<Question> GetMapQuestion3() { return mapQuestion3;}

        public void Start()
    {
        tutorialQuestion.Add(new Question()
        {
            question = "Pick one answer. The correct answer will turn in green otherwise it will turn in red.",
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
            question = "Which of these passwords is the most secure?",
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
                "'#' is the correct answer because it has more than 8 characters long, has lower and upper case, digits and special characters",
                "'#' is the correct answer because it has more than 8 characters long, has lower and upper case, digits and special characters",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 0,
        });
        allQuestion.Add(new Question()
        {
            question = "Which of these passwords is the most secure and easiest to remember?",
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
                "'#' is the correct answer because it has more than 8 characters long, has lower and upper case, digits and special characters" +
                "but also because it contains some word that is easy to remember.",
                "'#' is the correct answer because it has more than 8 characters long, has lower and upper case, digits and special characters" +
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
                "myOwlHedwige",
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
              "'#' is the correct answer because it can be found easily by searching informations about you on social network for example.",
              "'#' is the correct answer because it is a common password and hackers will try it first.",
              "'#' is the correct answer because it can be found easily by searching informations about you on social network for example.",
              "'#' is the correct answer because the length of the password is too short and can be found easily by a brute force attack."
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 2,
        });
        allQuestion.Add(new Question()
        {
            question = "Which of these requirements make a password more secure?",
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
            question = "What the encryption is used for?",
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
            question = "What hash functions are used for?",
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
            question = "In which domain is a password useful?",
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
                "'#' is the correct answer because it prevent unauthorized access to confidential informations.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 6,
        });
        allQuestion.Add(new Question()
        {
            question = "Which domain this definition refers to? 'preventing unauthorized disclosure of informations. Includes secrecy, privacy'?",
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
                "'#' is the correct answer because it can prevent unauthorized disclosure of informations.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 7,
        });
        allQuestion.Add(new Question()
        {
            question = "Which domain this definition refers to? 'preventing unauthorized modification of data and system'?",
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
            question = "Which domain this definition refers to? 'preventing downtime of systems or inability to access data/information'?",
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
            question = "Which of these methods confirm the truth of your identity?",
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
            question = "What is the definition of Authentication?",
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
            question = "What is the definition of Authorization?",
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
            question = "What is the definition of Non-repudiation?",
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
            question = "What is the cyber security?",
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
            question = "What is the information security?",
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
            question = "What is the technology security?",
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
            question = "Which word is used to protect cyber environment, organization and user's assets?",
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
                "'#' is the correct answer, the others are used in a cyber environment but don't protect.",
                "'#' is the correct answer, the others are used in a cyber environment but don't protect.",
                "'#' is the correct answer, the others are used in a cyber environment but don't protect.",
                "'#' is the correct answer, the others are used in a cyber environment but don't protect.",
                "'#' is the correct answer, the others are used in a cyber environment but don't protect.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 17,
        });
        allQuestion.Add(new Question()
        {
            question = "Which word is used in a cyber environment by organization and user's assets?",
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
                "'#' is the correct answer, the others are used to protect the cyber environment.",
                "'#' is the correct answer, the others are used to protect the cyber environment.",
                "'#' is the correct answer, the others are used to protect the cyber environment.",
                "'#' is the correct answer, the others are used to protect the cyber environment.",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 18,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What word refers to this definition 'Weakness in the system, could originate from design, implementation, context, … '",
            goodAnswer = new List<string>()
            {
                "vulnerability",
            },
            badAnswer = new List<string>()
            {
              "threat",
              "attack",
              "control",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 19,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What word refers to this definition 'Circumstances or events that could potentially lead to harm or lost'",
            goodAnswer = new List<string>()
            {
                "threat",
            },
            badAnswer = new List<string>()
            {
                "vulnerability",
                "attack",
                "control",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 20,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What word refers to this definition 'Attempt to exploit a vulnerability'",
            goodAnswer = new List<string>()
            {
                "attack",
            },
            badAnswer = new List<string>()
            {
                "vulnerability",
                "threat",
                "control",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 21,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What word refers to this definition 'Action used to remove or limit a vulnerability'",
            goodAnswer = new List<string>()
            {
                "control",
            },
            badAnswer = new List<string>()
            {
                "vulnerability",
                "threat",
                "attack",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 22,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What type of attack refers to 'An unauthorized party gains access to an asset'?",
            goodAnswer = new List<string>()
            {
                "Interception",
            },
            badAnswer = new List<string>()
            {
                "Interruption",
                "Modification",
                "Fabrication",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 23,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What type of attack refers to 'An asset is destroyed or becomes unavailable'?",
            goodAnswer = new List<string>()
            {
                "Interruption",
            },
            badAnswer = new List<string>()
            {
                "Interception",
                "Modification",
                "Fabrication",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 24,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What type of attack refers to 'An unauthorized party modify an asset'?",
            goodAnswer = new List<string>()
            {
                "Modification",
            },
            badAnswer = new List<string>()
            {
                "Interception",
                "Interruption",
                "Fabrication",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 25,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What type of attack refers to 'An unauthorized party insert counterfeit objects into the system'?",
            goodAnswer = new List<string>()
            {
                "Fabrication",
            },
            badAnswer = new List<string>()
            {
                "Interception",
                "Interruption",
                "Modification",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 26,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What type of attack refers to 'An unauthorized party insert counterfeit objects into the system'?",
            goodAnswer = new List<string>()
            {
                "Fabrication",
            },
            badAnswer = new List<string>()
            {
                "Interception",
                "Interruption",
                "Modification",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 27,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Access to confidential information'?",
            goodAnswer = new List<string>()
            {
                "Interception",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interruption",
                "Modification",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because the Interception allows the attacker to get informations",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 28,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Copying copyrighted information'?",
            goodAnswer = new List<string>()
            {
                "Interception",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interruption",
                "Modification",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because the Interception allows the attacker to get informations",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 29,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Hardware stolen (e.g. phone, laptop, smart device)'?",
            goodAnswer = new List<string>()
            {
                "Interception",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interruption",
                "Modification",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because the Interception allows the attacker to get informations",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 30,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Network attack (e.g. Distributed Denial of service (DDOS))'?",
            goodAnswer = new List<string>()
            {
                "Interruption",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interception",
                "Modification",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because a DDOS can make a website unavailable",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 31,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Changing a bank account in a database'?",
            goodAnswer = new List<string>()
            {
                "Modification",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interception",
                "Interruption",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because it will change the value of your bank account in the database",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 32,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Website defacement (When an attacker changes a website after breaking into it.)'?",
            goodAnswer = new List<string>()
            {
                "Modification",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interception",
                "Interruption",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because it will change the website",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 33,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Altering a program'?",
            goodAnswer = new List<string>()
            {
                "Modification",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interception",
                "Interruption",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because it will change the program",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 34,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Changing the content of an email'?",
            goodAnswer = new List<string>()
            {
                "Modification",
            },
            badAnswer = new List<string>()
            {
                "Fabrication",
                "Interception",
                "Interruption",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because it will change the content of the email",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 35,
        });
        mapQuestion2.Add(new Question()
        {
            question = "What attack type is it: 'Add records in a database'?",
            goodAnswer = new List<string>()
            {
                "Fabrication",
            },
            badAnswer = new List<string>()
            {
                "Modification",
                "Interception",
                "Interruption",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, because it will add a new record in the database",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 36,
        });
        mapQuestion2.Add(new Question()
        {
            question = "Which one of the following attacker types is an amateur?",
            goodAnswer = new List<string>()
            {
                "Script Kiddies",
            },
            badAnswer = new List<string>()
            {
                "Crackers",
                "Hacktivists",
                "Terrorists",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 37,
        });
        mapQuestion2.Add(new Question()
        {
            question = "Which one of the following attacker types use the knowledge of an underground community?",
            goodAnswer = new List<string>()
            {
                "Crackers",
            },
            badAnswer = new List<string>()
            {
                "Script Kiddies",
                "Hacktivists",
                "Terrorists",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 38,
        });
        mapQuestion2.Add(new Question()
        {
            question = "Which one of the following attacker types hack for a specific cause?",
            goodAnswer = new List<string>()
            {
                "Hacktivists",
            },
            badAnswer = new List<string>()
            {
                "Crackers",
                "Script Kiddies",
                "Terrorists",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 39,
        });
        mapQuestion2.Add(new Question()
        {
            question = "Which one of the following attacker types hack to destroy?",
            goodAnswer = new List<string>()
            {
                "Terrorists",
            },
            badAnswer = new List<string>()
            {
                "Crackers",
                "Hacktivists",
                "Script Kiddies",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 40,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which of the following process correspond to this sentence: 'Find what assets are important in a company.'?",
            goodAnswer = new List<string>()
            {
                "identify",
            },
            badAnswer = new List<string>()
            {
                "analyse",
                "treat",
                "monitor",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 41,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which of the following process correspond to this sentence:'Determine threats that an asset may face.'?",
            goodAnswer = new List<string>()
            {
                "identify",
            },
            badAnswer = new List<string>()
            {
                "analyse",
                "treat",
                "monitor",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 42,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which of the following process correspond to this sentence: 'Find vulnerabilities that may be exploited.'?",
            goodAnswer = new List<string>()
            {
                "identify",
            },
            badAnswer = new List<string>()
            {
                "analyse",
                "treat",
                "monitor",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 43,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which of the following process correspond to this sentence: 'Determine the probability of occurrence.'?",
            goodAnswer = new List<string>()
            {
                "analyse",
            },
            badAnswer = new List<string>()
            {
                "identify",
                "treat",
                "monitor",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 44,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which of the following process correspond to this sentence: 'Define the impact/harm/loss to the related asset.'?",
            goodAnswer = new List<string>()
            {
                "analyse",
            },
            badAnswer = new List<string>()
            {
                "identify",
                "treat",
                "monitor",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 45,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which of the following process correspond to this sentence: 'Determine risk rating by combining probability and impact.'?",
            goodAnswer = new List<string>()
            {
                "analyse",
            },
            badAnswer = new List<string>()
            {
                "identify",
                "treat",
                "monitor",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 46,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What can you determine by compiling the organizational experience, published reports, the estimated cost of attack, the attractiveness of a target and the vulnerability exposure?",
            goodAnswer = new List<string>()
            {
                "attack probability",
            },
            badAnswer = new List<string>()
            {
                "impact valuation",
                "risk level",
                "vulnerability",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 47,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What is the security risk management?",
            goodAnswer = new List<string>()
            {
                "Respond to risk",
            },
            badAnswer = new List<string>()
            {
                "risk level",
                "impact evaluation",
                "vulnerability",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, the other parts of the risk management are: Establish the context, Assess risk, Monitor Risk",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 48,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What are the main component of the security risk management lifecycle?",
            goodAnswer = new List<string>()
            {
                "Identify",
            },
            badAnswer = new List<string>()
            {
                "patch",
                "impact evaluation",
                "Respond to risk",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer, the other parts of the risk management lifecycle are: Analyse, Treat, Monitor",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 49,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What is the Risk?",
            goodAnswer = new List<string>()
            {
                "Something related to Threat, Assets and Vulnerability",
            },
            badAnswer = new List<string>()
            {
                "Something related to Threat and Assets",
                "Something related to threat and Vulnerability",
                "Something related to Vulnerability and Assets",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 50,
        });
        mapQuestion3.Add(new Question()
        {
            question = "Which one is a key asset?",
            goodAnswer = new List<string>()
            {
                "Money",
                "informations",
            },
            badAnswer = new List<string>()
            {
                "Cars",
                "Planes",
                "Laptop",
                "Computer",
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 51,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What will be the consequences of a loss of confidentiality?",
            goodAnswer = new List<string>()
            {
                "legal implications",
        },
            badAnswer = new List<string>()
            {
                "cost of lost work",
                "recovering costs",
                "reputation",
                
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 52,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What will be the consequences of a loss of integrity/unavailability?",
            goodAnswer = new List<string>()
            {
                "recovering costs",
                "cost of lost work",
            },
            badAnswer = new List<string>()
            {
                "legal implications",
                "nothing",
                "reputation",
                
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 53,
        });
        mapQuestion3.Add(new Question()
        {
            question = "What will be the consequences of an indirect harm?",
            goodAnswer = new List<string>()
            {
                "reputation",
            },
            badAnswer = new List<string>()
            {
                "legal implications",
                "recovering costs",
                "cost of lost work",
                
            },
            explanation = new List<string>()
            {
                "'#' is the correct answer",
            },
            hasAnsweredCorrectly = false,
            hasAnswered = false,
            index = 54,
        });
    }
}