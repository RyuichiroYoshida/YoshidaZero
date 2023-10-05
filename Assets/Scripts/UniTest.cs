using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class UniTest : MonoBehaviour
{
    private async void Start()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        await UniTask.WhenAll(WaitSce(1, token, cts), WaitSce(5, token, cts));
        cts.Cancel();
    }
    private async UniTask WaitSce(float sec, CancellationToken token, CancellationTokenSource cts)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(sec), cancellationToken: token);
        print(sec);
    }
}
