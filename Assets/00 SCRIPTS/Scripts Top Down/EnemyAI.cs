using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.TextCore.Text;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float nextWayPointDistance = 2f;
    [SerializeField]  float repeatTimeUpdatePath = 0.5f;
    [SerializeField] SpriteRenderer characterSR;
    [SerializeField] Animator animator;
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;

    Path path;
    Seeker seeker;
    Rigidbody2D rb;
    Health PlayerHealth;

    Coroutine moveCoroutine;

    public float freezeDurationTime;
    float freezeDuration;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        freezeDuration = 0;
        target = GameManagerTopdown.Instant.Player.transform;

        InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);
    }

    void CalculatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathCompleted);
    }

    void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    public void FreezeEnemy()
    {
        freezeDuration = freezeDurationTime;
    }

    IEnumerator MoveToTargetCoroutine()
    {
      
           
        int currentWP = 0;

        while (currentWP < path.vectorPath.Count)
        {
            while (freezeDuration > 0)
            {
                freezeDuration -= Time.deltaTime;
                yield return null;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
            if (distance < nextWayPointDistance)
                currentWP++;

            if (force.x != 0)
                if (force.x < 0)
                    characterSR.transform.localScale = new Vector3(1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth = collision.GetComponent<Health>();
            InvokeRepeating("DamagePlayer", 0, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("DamagePlayer");
            PlayerHealth = null;
        }
       
    }

    void DamagePlayer()
    {
        int damage = Random.Range(minDamage, maxDamage);
        PlayerHealth.TakeDam(damage);
        //
        PlayerHealth.GetComponent<Player_Controller>().TakeDamageEffect(damage);
    }
}
