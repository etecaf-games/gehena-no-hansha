﻿using UnityEngine;
using UnityEngine.UI;
public class CreativeButtons : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.01f;
    }
}