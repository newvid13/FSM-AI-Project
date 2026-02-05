using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Action/MoveToPoint")]
public class FSMAction_MoveToPatrolPoint : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        NavMeshAgent agent = machine.GetComponent<NavMeshAgent>();
        PatrolPoints points = machine.GetComponent<PatrolPoints>();

        agent.SetDestination(points.GetCurrentPoint().position);
    }
}
