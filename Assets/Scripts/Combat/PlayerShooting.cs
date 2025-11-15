using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    public GameObject projectilePrefab;
    public Transform firePoint; 

    [Header("Gun stats")]
    public float fireCooldown = 0.2f;    public float projectileSpeed = 25f;
    public float projectileDamage = 10f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (projectilePrefab == null || firePoint == null) return;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 dir = (mousePos - transform.position).normalized;

        var go = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        var proj = go.GetComponent<Projectile>();
        if (proj != null)
        {
            proj.Init(dir, projectileSpeed, projectileDamage);
        }
        else
        {
            var rb = go.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = dir.normalized * projectileSpeed;
                Destroy(go, 3f);
            }
        }

        Debug.Log("PlayerShooting: Shot fired");
    }
}
