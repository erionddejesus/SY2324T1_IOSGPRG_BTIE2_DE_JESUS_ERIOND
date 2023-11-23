using UnityEngine;

public class Wander : EnemyBaseFSM
{    
    [SerializeField] private float _destinationTimer;
    private float _currenDestinationTimer;

    private Vector3 _destination;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_currenDestinationTimer > 0)
        {
            _currenDestinationTimer -= Time.deltaTime;
        }

        if (_currenDestinationTimer <= 0)
        {
            _destination = _enemy.SetNewDestination();
            _currenDestinationTimer = _destinationTimer;
        }

        _enemy.LookAtTarget(_destination);
        _enemy.MoveToTarget();
    }
}
