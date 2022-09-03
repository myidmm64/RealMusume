using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MusumeMove : MonoBehaviour
{
    private int _speed = 10;
    public int Speed
    {
        get => _speed;
        set => _speed = value;
    }
    private int _bossLuck = 5;
    public int BossLuck
    {
        get => _bossLuck;
        set => _bossLuck = value;
    }
    private int _mapLuck = 5;
    public int MapLuck
    {
        get => _mapLuck;
        set => _mapLuck = value;
    }
    private string _name = "";
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    private Transform _endPosition = null;
    private Animator _animator = null;
    private Slider _slider = null;
    private NavMeshAgent _agent = null;
    private readonly int _runHash = Animator.StringToHash("IsRunning");
    private bool _runStarted = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _endPosition = GameObject.FindGameObjectWithTag("EndPosition").transform;
        _slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        _agent.speed = _speed;
    }

    private void Update()
    {
        Move();
        SliderSet();
    }

    private void SliderSet()
    {

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
            _agent.SetDestination(_endPosition.transform.position);
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
