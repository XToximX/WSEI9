using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplay;
    [SerializeField] Slider xpBar;
    [SerializeField] GameObject lvlUpMenu;
    [SerializeField] EnemyMgr enemyMgr;
    [SerializeField] SoundMgr soundMgr;
    [SerializeField] List<TMP_Text> stats;
    [SerializeField] GameObject canva;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject deathCanva;

    private static int score;
    private float timer = 0f;
    public static int enemiesKilled = 0;
    public static int bulletsReflected = 0;
    public static int collectibles = 0;

    private float xpTarget = 500;
    private static float currentxP = 0;

    public static float combo = 0f;
    private static float maxCombo = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvlUpMenu.SetActive(false);
        StartCoroutine(ScoreUp());

        score = 0;
        enemiesKilled = 0;
        bulletsReflected = 0;
        collectibles = 0;
        currentxP = 0;
}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

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

        if(enemyMgr.spawnDelay > 2f)
            enemyMgr.spawnDelay -= 0.05f;
        if (enemyMgr.spawnDelay < 3 && soundMgr.currTrack != 1)
            soundMgr.changeMusic(1);

    }

    public void EndLvlUp()
    {
        currentxP = 0;
        Time.timeScale = 1f;
        lvlUpMenu.SetActive(false);
        xpTarget *= 1.2f;
    }

    public void ImDead()
    {
        pauseMenu.SetActive(false);
        soundMgr.PlaySFX(0);
        Time.timeScale = 0f;
        canva.SetActive(false);
        deathCanva.SetActive(true);
        Player.instance.SetActive(false);

        stats[0].text = stats[0].text + Mathf.Floor(timer).ToString();
        stats[1].text = stats[1].text + score.ToString();
        stats[2].text = stats[2].text + enemiesKilled.ToString();
        stats[3].text = stats[3].text + bulletsReflected.ToString();
        stats[4].text = stats[4].text + collectibles.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game 111");
    }

    public void QuitGame()
    {
        Application.Quit();
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
