using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private bool _isGrounded;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

        float translation = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;

        _transform.Translate(0, 0, translation);
        _transform.Rotate(0, rotation, 0);
    }
}
