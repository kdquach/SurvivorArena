
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHp = 30;

    private int currentHp;

    public int CurrentHp => currentHp;
    public int MaxHp => maxHp;
    public bool IsDead => currentHp <= 0;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead || damage <= 0) return;

        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);

        Debug.Log("Enemy HP: " + currentHp);

        if (IsDead)
        {
            Die();
        }
    }

    
void Die()
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    if (player != null)
    {
        PlayerExperience experience =
            player.GetComponent<PlayerExperience>();

        if (experience != null)
        {
            experience.GainXP(10);
        }
    }

    Destroy(gameObject);
}
}