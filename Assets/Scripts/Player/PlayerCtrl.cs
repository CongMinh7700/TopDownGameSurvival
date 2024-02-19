using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : ShootableObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Player.ToString();
    }

}
