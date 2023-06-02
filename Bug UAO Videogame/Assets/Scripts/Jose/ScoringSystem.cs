using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI textScore;
  //  public GameObject scoreText;
    public  int score;

    public GameObject sd1;
    public GameObject sd2;
    public GameObject sd3;
    public GameObject sd4;
    public GameObject sd5;
    public GameObject sd6;
    public GameObject sd7;
    public GameObject sd8;
    public GameObject sd9;
    public GameObject sd10;

    private void Start()
    {
        
    }

    void Update()
    {
        addScore();
        // scoreText.GetComponent<Text>().text = "SDs: " + score;
    }

    public  void AddScore()
    {
        score += 1;
        textScore.text = "SDs: " + score;

    }

    public void addScore()
    {
        if (score == 1)
        {
            sd1.SetActive(true);
        }
        else if (score == 2)
        {
            sd2.SetActive(true);
            sd1.SetActive(false);
        }
        else if (score == 3)
        {
            sd3.SetActive(true);
            sd2.SetActive(false);
        }
        else if (score == 4)
        {
            sd4.SetActive(true);
            sd3.SetActive(false);
        }
        else if (score == 5)
        {
            sd5.SetActive(true);
            sd4.SetActive(false);
        }
        else if (score == 6)
        {
            sd6.SetActive(true);
            sd5.SetActive(false);
        }
        else if (score == 7)
        {
            sd7.SetActive(true);
            sd6.SetActive(false);
        }
        else if (score == 8)
        {
            sd8.SetActive(true);
            sd7.SetActive(false);
        }
        else if (score == 9)
        {
            sd9.SetActive(true);
            sd8.SetActive(false);
        }
        else if (score == 10)
        {
            sd10.SetActive(true);
            sd9.SetActive(false);
        }
    }
}
