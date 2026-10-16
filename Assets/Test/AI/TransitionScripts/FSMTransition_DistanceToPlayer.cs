using UnityEngine;
using FSMAI;

[CreateAssetMenu(menuName = createPath + "DistanceToPlayer")]
public class FSMTransition_DistanceToPlayer : FSMTransition
{
    public float requiredDistance;

    public override bool Decide(StateMachine machine)
    {
        EnemySight sight = machine.GetComponent<EnemySight>();

        if (sight.DistanceToPlayer() < requiredDistance)
            return true;
        else
            return false;
    }
}
