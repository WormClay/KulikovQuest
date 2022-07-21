using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))] 
public class FollowingEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    private bool isVisiblePlayer = false;
    private string tagPlayer = "Player";
    private float checkStep = 1f;  
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
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisiblePlayer) 
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
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
}
