using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

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
