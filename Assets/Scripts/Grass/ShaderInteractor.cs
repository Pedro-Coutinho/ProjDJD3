﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderInteractor : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_PositionMoving", transform.position);
    }
}
