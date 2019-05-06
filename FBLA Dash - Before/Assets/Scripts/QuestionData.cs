using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// store single question with a pool of answers (but only one is correct)
/// </summary>
[System.Serializable]
public class QuestionData 
{
    public string questionText;
    public AnswerData[] answers;
}
