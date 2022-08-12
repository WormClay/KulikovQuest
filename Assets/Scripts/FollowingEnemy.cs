using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]

public class FollowingEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    private bool isVisiblePlayer = false;
    private string tagPlayer = "Player";
    private float checkStep = 1f;
    [SerializeField] private int damage = 10;
    private Animator animator;
    [SerializeField] private float speed;
    

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>().transform;
        StartCoroutine(CheckVisiblePlayer());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckVisiblePlayer());
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isVisiblePlayer) 
        {
            agent.SetDestination(player.position);
            animator.SetBool("isAngry", true);
        }
        else
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            animator.SetBool("isAngry", false);
        }
    }

    IEnumerator CheckVisiblePlayer()
    {
        while (enabled)
        {
            if (Physics.Raycast(new Ray(transform.position, player.position - transform.position), out RaycastHit hitInfo, 10f))
                if (hitInfo.transform.CompareTag(tagPlayer)) isVisiblePlayer = true;
                else isVisiblePlayer = false;
            yield return new WaitForSeconds(checkStep);
        }
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerObjects helth))
        {
            helth.Hit(damage);
            //Debug.Log($"damage = {damage}");
        }
    }

}
