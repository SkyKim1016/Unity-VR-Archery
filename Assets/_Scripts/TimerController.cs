using UnityEngine;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float _desiredDuration = 60f; // The desired duration in seconds

    private Animator _animator;

    public UnityEvent TimeOut;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SetAnimationSpeed();
    }

    public void PlayAnimation()
    {
        _animator.enabled = true;
    }

    public void StopAnimation()
    {
        TimeOut.Invoke();
        _animator.enabled = false;
    }

    public void SetDesiredDuration(float duration)
    {
        _desiredDuration = duration;
        SetAnimationSpeed();
    }

    private void SetAnimationSpeed()
    {
        float speedFactor = 1 / _desiredDuration;

        // Set the animator parameter
        _animator.SetFloat("speedFactor", speedFactor);
    }
}