using UnityEngine;

public class GameEnd : IState
{
    GameStateManager _stateManager;

    public GameEnd(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("Game End");
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
