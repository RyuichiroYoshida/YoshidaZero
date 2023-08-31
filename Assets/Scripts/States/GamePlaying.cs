using UnityEngine;

public class GamePlaying : IState
{
    GameStateManager _stateManager;

    public GamePlaying(GameStateManager stateManager)
    {
        this._stateManager = stateManager;
    }
    public void Enter()
    {
        // �ŏ��ɏ�Ԃɓ������Ƃ��Ɏ��s�����R�[�h
        Debug.Log("Game Playing");
    }
    public void Update()
    {
        // �t���[���P�ʂ̃��W�b�N�ŁA�V������ԂɈڍs���邽�߂̏������܂�
        if (_stateManager.StageManager.StageClear)
            _stateManager.GameState.TransitionTo(_stateManager.GameState.gameEnd);
    }
    public void Exit()
    {
        // ��Ԃ𔲂���Ƃ��Ɏ��s�����R�[�h   
    }
}
