using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面UIの一括管理
/// GameDirectorと各画面を中継する役割
/// </summary>
public class UIManager : MonoBehaviour
{
    BaseCanvasManager[] canvases;
    void Start()
    {
        canvases = new BaseCanvasManager[transform.childCount];
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i] = transform.GetChild(i).GetComponent<BaseCanvasManager>();
            if (canvases[i] == null) { continue; }
            canvases[i].OnStart();
        }
    }

    void Update()
    {
        if (Variables.screenState == ScreenState.INITIALIZE)
        {
            Initialize();
        }
        else
        {
            OnUpdate();
        }
    }

    void OnUpdate()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            if (canvases[i] == null) { continue; }
            canvases[i].OnUpdate();
        }
    }

    void Initialize()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            if (canvases[i] == null) { continue; }
            canvases[i].OnInitialize();
        }
        Variables.screenState = ScreenState.GAME;
    }

}
