﻿using UnityEngine;
using System.Collections;

public class PentagramPointController : GameObjectController {
    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;
    public PentagramPointController pair;
    public PentagramGameController controller;
   
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMouseBeingDraggedOver() && controller.lineUnbroken)
        {
            if (isSelected)
            {
                select(false);
                GetComponent<AudioSource>().Play();
                controller.AddPoint(this);
                if (controller.phase < 3)
                {
                    pair.select(true);
                    
                } 
            }
        }

        if (IsBeingClicked() && isSelected)
        {
            controller.lineUnbroken = true;
        }

        if (!Input.GetMouseButton(0)) { 
            if (pair.isSelected && controller.lineUnbroken)
            {
                controller.lineUnbroken = false;
                pair.select(false);
                select(true);
                controller.RemovePoint(this);
            }
        }
	}

    public void select(bool selected)
    {
        isSelected = selected;
        if (selected)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
