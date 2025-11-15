using UnityEngine;

public class RunStatsCollector : MonoBehaviour
{
    public static RunStatsCollector Instance;

    public float damageDealt = 0f;
    public float damageTaken = 0f;
    public int enemiesKilled = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPlayerDealtDamage(float dmg)
    {
        damageDealt += dmg;
    }

    public void OnPlayerTookDamage(float dmg)
    {
        damageTaken += dmg;
    }

    public void OnEnemyKilled()
    {
        enemiesKilled++;
    }
}

