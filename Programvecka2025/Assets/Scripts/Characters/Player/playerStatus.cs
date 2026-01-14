using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInteracter", menuName = "Scriptable Objects/PlayerInteracter")]
public class playerStatus : MonoBehaviour
{
    public string charName;
    public float[] position = new float[2];
    public GameObject characterGameObject;
    public int level;
    public int health;
    public Component player;


    public playerStatus(string charName, float[] position, GameObject characterGameObject, int level, int health, Component player)
    {
        this.charName = charName;
        this.health = health;
        this.position = position;
        this.characterGameObject = characterGameObject;
        this.level = level;
        this.player = player;
    }

}



