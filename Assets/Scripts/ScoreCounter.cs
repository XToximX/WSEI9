using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplay;
    [SerializeField] Slider xpBar;
    [SerializeField] GameObject lvlUpMenu;
    [SerializeField] EnemyMgr enemyMgr;

    private static int score;

    private float xpTarget = 500;
    private static float currentxP = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvlUpMenu.SetActive(false);
        StartCoroutine(ScoreUp());
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
        xpBar.value = currentxP / xpTarget;

        if(currentxP >= xpTarget)
        {
            LvlUp();
        }
    }
    
    public static void AddScore(int value)
    {
        score += value;
        currentxP += value;
    }

    private void DisplayScore()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    public void LvlUp()
    {
        Time.timeScale = 0f;
        lvlUpMenu.SetActive(true);

        if(enemyMgr.spawnDelay > 1f)
            enemyMgr.spawnDelay -= 0.2f;
    }

    public void EndLvlUp()
    {
        currentxP = 0;
        Time.timeScale = 1f;
        lvlUpMenu.SetActive(false);
        xpTarget *= 1.2f;
    }
    
    IEnumerator ScoreUp()
    {
        while(true)
        {
            score += 5;
            currentxP += 5;
            yield return new WaitForSeconds(1);
        }
    }
}
