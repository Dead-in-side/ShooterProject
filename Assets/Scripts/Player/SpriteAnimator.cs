using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class SpriteAnimator : MonoBehaviour
{
    private readonly int IsShot = Animator.StringToHash(nameof(IsShot));
    private readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isShot = false;
    private bool _isWalk = false;
    private float _duration = 0f;
    private float _maxDelay = 1f;
    private float _minMovemant = 0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _duration += Time.deltaTime;

        if (_isShot && _duration >= _maxDelay)
        {
            _isShot = false;
            _animator.SetBool(IsShot, _isShot);
        }

        _animator.SetBool(IsWalk, _isWalk);
    }

    public void Walk(float directionX, float directionZ) => _isWalk = directionX != _minMovemant || directionZ != -_minMovemant;

    public void Shot()
    {
        _isShot = true;
        _animator.SetBool(IsShot, _isShot);
        _duration = 0f;
    }
}
