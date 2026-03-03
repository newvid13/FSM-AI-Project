using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnLocation;
    [SerializeField] float reloadTime;
    bool isReady = true;

    InputAction fireAction;

    private void Start()
    {
        fireAction = InputSystem.actions.FindAction("Attack");
        fireAction.started += ctx => Fire();
    }

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
