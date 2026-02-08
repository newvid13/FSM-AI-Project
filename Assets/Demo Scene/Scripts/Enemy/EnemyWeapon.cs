using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] ParticleSystem attackPart;
    [SerializeField] float reloadTime;
    bool isReady = true;

    public void Fire()
    {
        if (!isReady)
            return;

        attackPart.Play();
        isReady = false;
        Reload();
    }

    private async void Reload()
    {
        await Awaitable.WaitForSecondsAsync(reloadTime);
        isReady = true; ;
    }
}
