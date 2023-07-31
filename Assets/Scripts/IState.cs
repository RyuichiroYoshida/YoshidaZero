using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter()
    {
        // 最初に状態に入ったときに実行されるコード
    }
    public void Update()
    {
        // フレーム単位のロジックで、新しい状態に移行するための条件を含む
    }
    public void Exit()
    {
        // 状態を抜けるときに実行されるコード   
    }
}
