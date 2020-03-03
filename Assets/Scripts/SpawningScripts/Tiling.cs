using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : BaseTiling {

    protected override void Start()
    {
        base.Start();
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
