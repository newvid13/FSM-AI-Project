using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Action/Stop")]
public class FSMAction_StopMoving : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        NavMeshAgent agent = machine.GetComponent<NavMeshAgent>();
        agent.SetDestination(machine.transform.position);
    }
}
