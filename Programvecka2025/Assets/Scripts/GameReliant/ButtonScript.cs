using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    float time;
    bool delayYourTurn = false;
    private void Update()
    {
        time += Time.time;
        if(time >= 2f)
        {
            delayYourTurn = true;
        }
        else
        {
            delayYourTurn = false;
        }
    }
    [SerializeField] List<GameObject> listGameObjects = new List<GameObject>();
    [SerializeField] List<TextMeshProUGUI> textMeshProUGUIs = new List<TextMeshProUGUI>();
    public void AttackButton()
    {
        listGameObjects[0].SetActive(false);
        listGameObjects[1].SetActive(true);
        textMeshProUGUIs[0].SetText("Choose Your Attack!");
    }
    public void RunButton()
    {
        textMeshProUGUIs[0].SetText("You Haven't Sined Enough to Run!");
        time = 0f;
        while (!delayYourTurn)
        {
            
        }
        textMeshProUGUIs[0].SetText("Your Turn!");
        

    }
}
