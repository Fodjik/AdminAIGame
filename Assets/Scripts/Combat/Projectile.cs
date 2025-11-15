using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float lifetime = 3f;

    private Vector2 direction;

    public void Init(Vector2 dir, float speedOverride = -1f, float damageOverride = -1f)
    {
        direction = dir.normalized;
        if (speedOverride > 0) speed = speedOverride;
        if (damageOverride > 0) damage = damageOverride;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Projectile hit: " + col.name);
        

        var enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        if (!col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
