using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _targetsParent;
    [SerializeField] private float _speed;

    private List<Transform> _targets;
    private Transform _currentTarget;
    private int _targetIndex;
    
    void Start()
    {
        _targets = _targetsParent.GetComponentsInChildren<Transform>().ToList();
        _targetIndex = 0;
        _currentTarget = GetTarget();
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position,
                                                _speed * Time.deltaTime);

        if (transform.position == _currentTarget.position)
            _currentTarget = GetTarget();
    }

    private Transform GetTarget()
    {
        if (_targetIndex == _targets.Count)
            _targetIndex = 0;

        Transform target = _targets[_targetIndex];
        _targetIndex++;
        
        return target;
    }
}
