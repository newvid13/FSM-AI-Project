using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnLocation;

    [SerializeField] float reloadTime;
    bool isReady = true;

    public void Fire()
    {
        if (!isReady)
            return;

        Instantiate(bulletPrefab, bulletSpawnLocation.position, transform.rotation);

        isReady = false;
        Reload();
    }

    private async void Reload()
    {
        await Awaitable.WaitForSecondsAsync(reloadTime);
        isReady = true;
    }
}
