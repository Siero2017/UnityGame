using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            _animator.SetFloat(AnimatorPlayerController.Params.Speed, AnimatorPlayerController.States.Run);
        }
        else
        {
            _animator.SetFloat(AnimatorPlayerController.Params.Speed, AnimatorPlayerController.States.Idle);
        }

        float translation = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}

