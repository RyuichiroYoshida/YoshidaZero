using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator _playerAnimator;
    Input _playerInput;
    void Start()
    {
        _playerInput = GetComponent<Input>();
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
    public void PlayerAttackAnim()
    {

    }
}
