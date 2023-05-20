using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public GameObject scoreText;
    public  int score;

    private void Start()
    {
        
    }

    void Update()
    {
   
        scoreText.GetComponent<Text>().text = "SDs: " + score;
    }

    public  void AddScore()
    {
        score += 1;
        textScore.text = "SDs: " + score;

    }
}
