using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PlayerPrefs.SetFloat("playerx", 341);
        PlayerPrefs.SetFloat("playery", 66);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
