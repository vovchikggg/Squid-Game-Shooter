using System;
using UnityEngine;
using UnityEngine.AI;
using SquidGameShooter.Utils;

public class EnemyNoAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 7f;

    // private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamingPosition;
    private Vector3 startingPosition;
    
    private enum State
    {
        Idle,
        Roaming,
        Chasing,
        Attacking,
        Death
    }

    private void Awake()
    {
        // navMeshAgent = GetComponent<NavMeshAgent>();
        // navMeshAgent.updateRotation = false;
        // navMeshAgent.updateUpAxis = false;
        state = startingState;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }
                break;
            case State.Chasing:
                ChasingTarget();
                break;
            case State.Attacking:
                break;
            case State.Death:
                break;
            default:
            case State.Idle:
                break;
        }
    }

    private void Roaming()
    {
        startingPosition = transform.position;
        roamingPosition = GetRoamingPosition();
        // navMeshAgent.SetDestination(roamingPosition);
    }

    private void ChasingTarget()
    {
        // navMeshAgent.SetDestination(PlayerMove.Instance.transform.position);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }
}
