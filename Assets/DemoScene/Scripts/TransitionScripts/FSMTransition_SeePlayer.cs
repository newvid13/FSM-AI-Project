using UnityEngine;
using FSMAI;

[CreateAssetMenu(menuName = "FSM/Transitions/SeePlayer")]
public class FSMTransition_SeePlayer : FSMTransition
{
    public override bool Decide(StateMachine machine)
    {
        EnemySight sight = machine.GetComponent<EnemySight>();

        if (sight.seenPlayer != null)
            return true;
        else
            return false;
    }
}
