using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Action/Chase")]
public class FSMAction_Chase : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        NavMeshAgent agent = machine.GetComponent<NavMeshAgent>();
        EnemySight sight = machine.GetComponent<EnemySight>();

        if (sight.seenPlayer != null)
            agent.SetDestination(sight.seenPlayer.position);
    }
}
