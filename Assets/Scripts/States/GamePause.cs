using UnityEngine;

public class GamePause : IState
{
    GameStateManager _stateManager;

    public GamePause(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("Game Pause");
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