using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCopy : Ball {

    public bool unlocked = false;

    public void Unlock() {
        print("blah");
        rb.useGravity = true;
        launcher.balls.Add(rb);
        unlocked = true;
    }
}
