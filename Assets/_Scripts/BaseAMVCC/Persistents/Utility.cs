﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Utility
{
    public enum TouchState
    {
        Start,
        Drag,
        Drop
    }
    public enum Movement
    {
        SwipeLeft,
        SwipeRight,
        SwipeUp,
        SwipeDown,
        DragLeft,
        DragRight,
        DragUp,
        DragDown
    }
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
