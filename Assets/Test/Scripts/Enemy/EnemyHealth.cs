using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;

    public int GetHealth()
    { 
        return health; 
    }

    public void Damage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 10);
    }
}
