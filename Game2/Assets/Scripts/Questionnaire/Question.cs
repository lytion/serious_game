using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string question { get; set; }
    public List<string> goodAnswer { get; set; }
    public List<string> badAnswer { get; set; }
    public List<string> explanation { get; set; }
    public bool hasAnsweredCorrectly;
    public bool hasAnswered;
    public int index;
}
