using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartManager : GameMonoBehaviour
{
    [SerializeField] protected Transform startScreen;
    [SerializeField] protected Transform tutorialScreen;

    protected override void Start()
    {
        startScreen.gameObject.SetActive(true);
        tutorialScreen.gameObject.SetActive(false);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStartScreen();
        this.LoadTitleScreen();
    }
    protected virtual void LoadStartScreen()
    {
        if (this.startScreen != null) return;
        this.startScreen = FindObjectOfType<Canvas>().transform.Find("StartScreen");
        Debug.LogWarning(transform.name + "||LoadStartScreen||", gameObject);
    }
    protected virtual void LoadTitleScreen()
    {
        if (this.tutorialScreen != null) return;
        this.tutorialScreen = FindObjectOfType<Canvas>().transform.Find("TutorialScreen");
        Debug.LogWarning(transform.name + "||LoadTitleScreen||", gameObject);
    }
    public virtual void ShowTutorial()
    {
        startScreen.gameObject.SetActive(false);
        tutorialScreen.gameObject.SetActive(true);
    }
    public virtual void ExitTutorial()
    {
        startScreen.gameObject.SetActive(true);
        tutorialScreen.gameObject.SetActive(false);
    }
    public virtual void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public virtual void ExitGame()
    {
        // EditorApplication.ExitPlaymode();
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
