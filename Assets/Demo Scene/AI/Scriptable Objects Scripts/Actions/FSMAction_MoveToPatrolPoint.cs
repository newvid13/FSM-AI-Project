using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Action/MoveToPoint")]
public class FSMAction_MoveToPatrolPoint : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        NavMeshAgent agent = machine.GetComponent<NavMeshAgent>();
        EnemyPatrol patrol = machine.GetComponent<EnemyPatrol>();

        agent.SetDestination(patrol.GetCurrentPoint().position);
    }
}
