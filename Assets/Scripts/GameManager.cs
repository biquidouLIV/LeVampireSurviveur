using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject GameOverMenu;
    public PlayerController player;

    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    
    private void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    public void Pause()
    {
        Debug.Log("pause");
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (pauseMenu.activeSelf) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void LoadScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
        GameOverMenu.SetActive(true);
        
    }
    
}
