using UnityEngine;

public abstract class FSMTransition : ScriptableObject
{
    public abstract bool Decide(StateMachine machine);

}
