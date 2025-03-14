using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplay;
    private static int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScoreUp());
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }
    
    public static void AddScore(int value)
    {
        score += value;
    }

    private void DisplayScore()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }
    
    IEnumerator ScoreUp()
    {
        while(true)
        {
            score += 5;
            yield return new WaitForSeconds(1);
        }
    }
}
