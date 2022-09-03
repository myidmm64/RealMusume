using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MusumeMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private GameObject _endPosition = null;

    private Animator _animator = null;
    private NavMeshAgent _agent = null;
    private readonly int _runHash = Animator.StringToHash("IsRunning");

    private bool _runStarted = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.speed = _speed;
    }

    private void Update()
    {
        Move();

        PlayerTouchMove();
    }

    [ContextMenu("경기 시작")]
    private void MoveStart()
    {
        _runStarted = true;
        _animator.SetBool(_runHash, true);
    }

    private void MoveEnd()
    {
        _agent.ResetPath();
        _animator.SetBool(_runHash, false);
        Time.timeScale = 0.1f;
    }

    private void Move()
    {
        if (_runStarted)
        {
            if (Vector3.Distance(transform.position, _agent.destination) < 0.2f)
            {
                MoveEnd();
            }
        }
    }

    void PlayerTouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
            {
                _agent.SetDestination(Hit.point);
            }
        }
    }
}
