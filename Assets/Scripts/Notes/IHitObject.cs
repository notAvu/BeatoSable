using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IHitObject
{
    public static Action<NoteHitInfo> noteHit;

    public void Hit();
    public void Miss();
}
