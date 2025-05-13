using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Transform _targetsParent;
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _targets;

    private Transform _currentTarget;
    private int _targetIndex;
    
    private void Start()
    {
        _targetIndex = 0;
        _currentTarget = GetTarget();
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position,
                                                _speed * Time.deltaTime);

        if (IsDistanceZero())
            _currentTarget = GetTarget();
    }

    private Transform GetTarget()
    {
        if (_targetIndex == _targets.Count)
            _targetIndex = 0;

        Transform target = _targets[_targetIndex];
        transform.forward = target.position - transform.position;
        _targetIndex++;
        
        return target;
    }

    private bool IsDistanceZero()
    {
        bool isZero = false;
        Vector3 offset = _currentTarget.position - transform.position;
        float offsetSquare = offset.sqrMagnitude;

        if (offsetSquare == 0)
            isZero = true;

        return isZero;
    }

    #if UNITY_EDITOR
    [ContextMenu("FillChildList")]
    private void FillChildList()
    {
        _targets = new List<Transform>();
        int chiledAmout = _targetsParent.childCount;

        for (int i = 0; i < chiledAmout; i++)
        {
            Transform transform = _targetsParent.GetChild(i);

            if (transform.TryGetComponent(out Target component))
                _targets.Add(transform);
        }
    }

    #endif
}