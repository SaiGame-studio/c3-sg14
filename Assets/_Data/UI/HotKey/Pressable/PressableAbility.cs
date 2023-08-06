using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility: Pressable
{
    [SerializeField] protected AbilitiesCode ability;

    public override void Pressed()
    {
        //PlayerCtrl.Instance.PlayerAbility.Active(ability);
    }
}
