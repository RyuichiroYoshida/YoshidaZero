using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }
    public void PlayerDeadAnim(bool dead)
    {
        _playerAnimator.SetBool("IsDead", dead);
    }
    public void PlayerMoveAnim(bool walk)
    {
        _playerAnimator.SetBool("IsWalking", walk);
    }
    public void PlayerJumpAnim(bool jump)
    {
        _playerAnimator.SetBool("IsJumping", jump);
    }
    public void PlayerAirAnim(bool ground)
    {
        _playerAnimator.SetBool("IsGround", ground);
    }
    public void PlayerAttackAnim(bool attack)
    {
        _playerAnimator.SetBool("Attack", attack);
    }

    public void PlayerComboAttack1(bool attack)
    {
        _playerAnimator.SetBool("ComboAttack1", attack);
    }
}
