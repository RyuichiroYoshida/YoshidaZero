using UnityEngine;

public class GameStartState : IState
{
    GameStateManager stateManager;

    public GameStartState(GameStateManager stateManager)
    {
        this.stateManager = stateManager;
    }
    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("Game Start");
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
