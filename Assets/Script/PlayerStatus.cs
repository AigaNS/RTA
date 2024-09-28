using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "ScriptableObjects/PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    public int hp;
    public float attack;
    public float defense;
    public float speed;
    public float criticalRate;
    public float gravity;
    public float jumpSpeed;
    public float jumpLimitTime;
    public float jumpLimitHeight;
    public float respawnTime;
}
