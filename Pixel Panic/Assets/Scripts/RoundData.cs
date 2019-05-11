using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// pool of questionairs and scores statistic for a giving round of game
/// </summary>
[System.Serializable]
public class RoundData 
{
    public string name;
    public int timeLimitInSeconds;
    public int pointsAddedForCorrectAnswer;
    public QuestionData[] questions;

}
