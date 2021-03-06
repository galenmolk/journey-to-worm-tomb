using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace WormTomb.General
{
    public class PointerEvent : UnityEvent<PointerEventData> { }

    public class BoolEvent : UnityEvent<bool> { }

    [Serializable]
    public class Vector2Event : UnityEvent<Vector2> { }
}