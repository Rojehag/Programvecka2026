using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInteracter", menuName = "Scriptable Objects/PlayerInteracter")]
public class PlayerInteracter : ScriptableObject
{
    public string charName;
    public float[] position = new float[2];
    public GameObject characterGameObject;
    public int level;
    public int health;
}
