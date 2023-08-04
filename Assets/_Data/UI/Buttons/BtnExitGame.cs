using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitGame : BaseButton
{
    protected override void OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }
}
