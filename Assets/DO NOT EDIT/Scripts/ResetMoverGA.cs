using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMoverGA : GameActions
{
    public MovingPlatform mPlatform;

    public override void Action()
    {
        mPlatform.Restart();
    }
}
