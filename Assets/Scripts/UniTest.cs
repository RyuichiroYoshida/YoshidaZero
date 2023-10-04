using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class UniTest : MonoBehaviour
{
    private async void Start()
    {
        print("start");
        await UniTask.WhenAll(WaitSce(1), WaitSce(2), WaitSce(3));
        print("taskEnd");
    }

    private async UniTask StartTween(float sec)
    {
        await transform.DOMoveX(5, sec);
    }
    private async UniTask WaitSce(float sec)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(sec));
        print(sec);
    }
}
