using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decision/SeePlayer")]
public class FSMDecision_SeePlayer : FSMDecision
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
