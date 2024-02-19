using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
public class GameManager : GameMonoBehaviour
{
    //Giup chung ta khong can phai getComponent
    [SerializeField] protected static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected TextMeshProUGUI killText;
    [SerializeField] protected TextMeshProUGUI levelText;
    [SerializeField] protected int score;
    [SerializeField] protected int enemyKillCount = 0;
    [SerializeField] protected Transform gameOverScreen;
    [SerializeField] protected Transform pauseScreen;
    [SerializeField] protected Button pauseButton;
    [SerializeField] protected bool isGameOver = false;
    [SerializeField] protected bool canSpawnBoss = false;
    [SerializeField] protected float timeDelayToFinish = 1f;
    [SerializeField] protected int bossKillCount = 0;
    protected override void Awake()
    {
        if (GameManager.instance != null) Debug.Log("Only 1 GameManager allow to exist");
        GameManager.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScoreText();
        this.LoadKillText();
        this.LoadLevelText();
        this.LoadGameOverScreen();
        this.LoadPauseScreen();
        this.LoadPauseButton();
    }
    protected override void Start()
    {
        isGameOver = false;
        Time.timeScale = 1;
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        this.ResetScore();

    }
    protected virtual void Update()
    {
        this.SetLevelText();
        if (this.isGameOver) this.timeDelayToFinish -= Time.deltaTime;
        if (timeDelayToFinish <= 0) Time.timeScale = 0;

    }
    protected virtual void SetLevelText()
    {
        int level = MapCtrl.Instance.MapLevel.CurrentLevel;
        this.levelText.SetText("Level : " + level);

    }
    public void UpdateScore(int value)
    {

        this.enemyKillCount ++;
        this.score += value;
       this.scoreText.SetText("Score : " + this.score);
        this.killText.SetText("Kill : " + this.enemyKillCount);
    }
    public void ResetScore()
    {
        this.enemyKillCount = 0;
        this.score = 0;
    }
    protected virtual void LoadScoreText()
    {
        if (this.scoreText != null) return;
        this.scoreText = FindObjectOfType<Canvas>().transform.Find("UITopLeft").Find("Score").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "||LoadScoreText||", gameObject);
    } 
    protected virtual void LoadKillText()
    {
        if (this.killText != null) return;
        this.killText = FindObjectOfType<Canvas>().transform.Find("UITopLeft").Find("KillText").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "||LoadKillText||", gameObject);
    } 
    protected virtual void LoadLevelText()
    {
        if (this.levelText != null) return;
        this.levelText = FindObjectOfType<Canvas>().transform.Find("UITopCenter").Find("LevelText").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "||LoadLevelText||", gameObject);
    }
    protected virtual void LoadGameOverScreen()
    {
        if (this.gameOverScreen != null) return;
        this.gameOverScreen = FindObjectOfType<Canvas>().transform.Find("UICenter").Find("GameOverScreen");
        Debug.LogWarning(transform.name + "||LoadGameOverScreen||", gameObject);
    }
    protected virtual void LoadPauseScreen()
    {
        if (this.pauseScreen != null) return;
        this.pauseScreen = FindObjectOfType<Canvas>().transform.Find("UICenter").Find("PauseScreen");
        Debug.LogWarning(transform.name + "||LoadPauseScreen||", gameObject);
    }
    protected virtual void LoadPauseButton()
    {
        if (this.pauseButton != null) return;
        this.pauseButton = FindObjectOfType<Canvas>().GetComponentInChildren<Button>();
        Debug.LogWarning(transform.name + "||LoadPauseScreen||", gameObject);
    }

    public virtual void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public virtual void GameOver()
    {
        isGameOver = true;
        gameOverScreen.gameObject.SetActive(true);


    }
    public virtual void Resume()
    {
        Time.timeScale = 1;
        this.pauseScreen.gameObject.SetActive(false);
        this.pauseButton.gameObject.SetActive(true);
    }
    public virtual void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public virtual void PauseButton()
    {
        Time.timeScale = 0;
        this.pauseScreen.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public virtual bool CanSpawnBoss()
    {
        this.canSpawnBoss = false;
      
        if (this.enemyKillCount % 16 == 0 && enemyKillCount != 0)
        {
            this.canSpawnBoss = true;
            
        }
        return canSpawnBoss;
    }
    public virtual int BossKillCount()
    {
        return bossKillCount;
    }
    public virtual int BossKilled()
    {
        return bossKillCount++;
    }
    public virtual int ScoreText()
    {
        return this.score;
    }
}
