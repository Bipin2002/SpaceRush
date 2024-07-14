using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageLoader2 : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject countdownUI;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI totalKillsText;
    public TextMeshProUGUI healthText; 

    private HealthHandler healthHandler;

    void Start()
    {
        Time.timeScale = 1;
        healthHandler = FindObjectOfType<HealthHandler>();
        UpdateHealthDisplay(healthHandler.maxHealth); 
    }

    public void GameStart()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync("HomeScreen");
    }

    public void InGame()
    {
        SetActiveMenu(inGameUI);
    }

    public void Paused()
    {
        Time.timeScale = 0;
        SetActiveMenu(pausedUI);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        SetActiveMenu(gameOverUI);
        totalKillsText.text = Mathf.FloorToInt(ScoreHandler.instance.FinalScore()).ToString();
    }

    public void Winner()
    {
        SetActiveMenu(gameWinUI);
    }

    public void Resume()
    {
        StartCoroutine(ResumeWithCountdown());
    }

    private IEnumerator ResumeWithCountdown()
    {
        SetActiveMenu(countdownUI);

        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1);
            countdown--;
        }
        SetActiveMenu(inGameUI);
        countdownUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void SetActiveMenu(GameObject menuToShow)
    {
        inGameUI.SetActive(menuToShow == inGameUI);
        pausedUI.SetActive(menuToShow == pausedUI);
        gameOverUI.SetActive(menuToShow == gameOverUI);
        gameWinUI.SetActive(menuToShow == gameWinUI);
        countdownUI.SetActive(menuToShow == countdownUI);
    }

    public void UpdateHealthDisplay(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}
