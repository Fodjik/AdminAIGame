using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHp = 20f;
    private float hp;

    public System.Action onDeath;

    private void Awake()
    {
        hp = maxHp;
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
            Die();
    }

    void Die()
    {
        onDeath?.Invoke();
        Destroy(gameObject);
    }
}
