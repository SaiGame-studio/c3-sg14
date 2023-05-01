using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotKeyManager : MonoBehaviour
{
    private static InputHotKeyManager instance;
    public static InputHotKeyManager Instance { get => instance; }

    public bool isAlpha1 = false;
    public bool isAlpha2 = false;
    public bool isAlpha3 = false;
    public bool isAlpha4 = false;
    public bool isAlpha5 = false;
    public bool isAlpha6 = false;
    public bool isAlpha7 = false;

    void Awake()
    {
        if (InputHotKeyManager.instance != null) Debug.LogError("Only 1 InputHotKeyManager allow to exist");
        InputHotKeyManager.instance = this;
    }

    void Update()
    {
        this.GetHotKeyPress();
    }

    protected virtual void GetHotKeyPress()
    {
        this.isAlpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        this.isAlpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        this.isAlpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        this.isAlpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        this.isAlpha5 = Input.GetKeyDown(KeyCode.Alpha5);
        this.isAlpha6 = Input.GetKeyDown(KeyCode.Alpha6);
        this.isAlpha7 = Input.GetKeyDown(KeyCode.Alpha7);
    }

}
