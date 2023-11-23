using UnityEngine;

public class EnemyBaseFSM : StateMachineBehaviour
{
    protected GameObject _animator;
    protected GameObject _target;

    protected Enemy _enemy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator.gameObject;
        _enemy = _animator.GetComponent<Enemy>();
        _target = _enemy.GetTarget();
    }
}
