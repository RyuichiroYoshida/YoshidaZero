using UnityEngine;

public class GamePrepare : IState
{
    GameStateManager _stateManager;

    public GamePrepare(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("Game Prepare");
    }
    public void Update()
    {
        // �t���[���P�ʂ̃��W�b�N�ŁA�V������ԂɈڍs���邽�߂̏������܂�
    }
    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h   
    }
}
