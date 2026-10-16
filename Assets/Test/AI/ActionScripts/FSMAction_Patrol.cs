using UnityEngine;
using UnityEngine.AI;
using FSMAI;

[CreateAssetMenu(menuName = createPath + "Patrol")]
public class FSMAction_Patrol : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        NavMeshAgent agent = machine.GetComponent<NavMeshAgent>();
        EnemyPatrol patrol = machine.GetComponent<EnemyPatrol>();
        
        if(patrol.HasReachedPoint())
        {
            agent.SetDestination(patrol.GetNextPoint().position);
        }
    }
}
