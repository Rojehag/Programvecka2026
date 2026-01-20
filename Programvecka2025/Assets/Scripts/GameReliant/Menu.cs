using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
                pauseMenuUI.SetActive(true);
            }
        }
    }

    public void PauseGame()
    {
        
        
        Time.timeScale = 0f;

    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        
        Time.timeScale = 1f;
    }

    
}
