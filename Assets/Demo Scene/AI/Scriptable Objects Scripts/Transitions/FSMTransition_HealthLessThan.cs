using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transitions/HealthLessThan")]
public class FSMTransition_HealthLessThan : FSMTransition
{
    public int healthAmount;
    public override bool Decide(StateMachine machine)
    {
        EnemyHealth health = machine.GetComponent<EnemyHealth>();

        if (health.ReturnHealth() < healthAmount)
            return true;
        else
            return false;
    }
}
