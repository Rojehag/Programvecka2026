using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject pauseButtonUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        pauseButtonUI.SetActive(false);
        Time.timeScale = 0f;

    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        pauseButtonUI.SetActive(true);
        Time.timeScale = 1f;
    }

    
}
