using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{

    public GameObject scoreText;
    public static int score;

    void Update()
    {
        scoreText.GetComponent<Text>().text = "SDs: " + score;
    }
}
