using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// control game data
/// </summary>
public class DataController : MonoBehaviour {
    public RoundData[] allRoundData;


        /// <summary>
    /// initialize object state
    /// </summary>
    void Start ()  {
        DontDestroyOnLoad (gameObject);

    }

    /// <summary>
    /// To obtain data for a giving round. Current version supports only a single round.
    /// </summary>
    /// <returns></returns>
    public RoundData GetCurrentRoundData() {
        return allRoundData [0];
    }

    // Update is called once per frame
    void Update () {
    
    }
}
