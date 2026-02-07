using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Action/Patrol")]
public class FSMAction_Patrol : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        NavMeshAgent agent = machine.GetComponent<NavMeshAgent>();
        PatrolPoints points = machine.GetComponent<PatrolPoints>();
        
        if(points.HasReachedPoint())
        {
            agent.SetDestination(points.GetNextPoint().position);
        }
    }
}
