using UnityEngine;

public class Playerattack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    [SerializeField] private Transform firePoint;
    
    [SerializeField] private GameObject[] fireball;

    private Animator anim;

    private PlayerMovement playermovement;

    private float cooldownTimer = Math.Infinty;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += cooldownTimer.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireball(0).transform.position = fireball.position;
        fireball(0).GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
