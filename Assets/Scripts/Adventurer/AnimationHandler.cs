using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private static readonly int StateIdle = Animator.StringToHash(AnimationParameters.IsIdle);
    private static readonly int StateWalking = Animator.StringToHash(AnimationParameters.IsWalking);
    private static readonly int StateRunning = Animator.StringToHash(AnimationParameters.IsRunning);
    private static readonly int StateJump = Animator.StringToHash(AnimationParameters.JumpTrigger);
    private static readonly int IsGround = Animator.StringToHash(AnimationParameters.IsGround);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateStateAnimator(AdventureState state)
    {
        _animator.SetBool(StateIdle, state == AdventureState.Idle);
        _animator.SetBool(StateWalking, state == AdventureState.Walking);
        _animator.SetBool(StateRunning, state == AdventureState.Running);
    }

    public void AnimateJump()
    {
        _animator.SetTrigger(StateJump);
    }

    public void SetGroundState(bool isGround)
    {
        _animator.SetBool(IsGround, isGround);
    }
}