using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[Serializable]
public class PointerEvent : UnityEvent<PointerEventData> { }

public class BoolEvent : UnityEvent<bool> { }

public class Vector2Event : UnityEvent<Vector2> { }

public class FloatEvent : UnityEvent<float> { }