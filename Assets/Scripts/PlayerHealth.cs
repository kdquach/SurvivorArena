
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHp = 100;

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

        Debug.Log("Player HP: " + currentHp);

        if (IsDead)
        {
            Debug.Log("Player has died!");
        }
    }
}