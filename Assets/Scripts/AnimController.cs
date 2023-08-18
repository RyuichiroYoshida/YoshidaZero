using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }
    
    public void PlayerMoveAnim(bool walk)
    {
        _playerAnimator.SetBool("IsWalking", walk);
    }
    public void PlayerJumpAnim(bool jump)
    {
        _playerAnimator.SetBool("IsJumping", jump);
    }
    public void PlayerAttackAnim(bool attack)
    {
        _playerAnimator.SetBool("Attack1", attack);
    }

    public void PlayerComboAttack1(bool attack)
    {
        _playerAnimator.SetBool("Attack2", attack);
    }
}
