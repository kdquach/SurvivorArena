
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 0.5f;

    private float nextAttackTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Time.time < nextAttackTime) return;

        nextAttackTime = Time.time + attackCooldown;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange
        );

        bool hitAnyEnemy = false;

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            EnemyHealth enemyHealth =
                enemyCollider.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null && !enemyHealth.IsDead)
            {
                enemyHealth.TakeDamage(damage);
                hitAnyEnemy = true;
            }
        }

        if (hitAnyEnemy)
        {
            Debug.Log("Player attacked!");
        }
        else
        {
            Debug.Log("No enemy in attack range.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}