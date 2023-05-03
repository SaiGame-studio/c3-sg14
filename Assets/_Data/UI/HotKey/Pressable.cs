using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressable : SaiMonoBehaviour
{
    public virtual void Pressed()
    {
        Debug.Log("Pressed: "+transform.parent.parent.name);
    }
}
