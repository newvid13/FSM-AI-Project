using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;

    private void Start()
    {
        TestWait();
    }

    public int ReturnHealth()
    { 
        return health; 
    }

    private async void TestWait()
    {
        await Awaitable.WaitForSecondsAsync(10);
        health = 0;
    }
}
