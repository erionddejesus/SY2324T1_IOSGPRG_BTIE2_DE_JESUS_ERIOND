using UnityEngine;

public class Seek : EnemyBaseFSM
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_target != null)
        {
            _enemy.GetComponent<Enemy>().LookAtTarget(_target.transform.position);
            _enemy.GetComponent<Enemy>().MoveToTarget();
        }
    }
}