using UnityEngine;

public class Destroy : EnemyBaseFSM
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_target != null)
        {
            _enemy.LookAtTarget(_target.transform.position);
            _enemy.Shoot();
        }
    }
}
