using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject pauseMenu;
    public PlayerController player;

    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void LoadScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index);
    }
    
    
}
