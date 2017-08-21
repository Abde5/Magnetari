using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils{

	public static float CollisionForce = 1f;

	// copy component to another object (for ball collider)
	public static T CopyComponent<T>(T original, GameObject destination) where T : Component {
      System.Type type = original.GetType();
      Component copy = destination.AddComponent(type);
      System.Reflection.FieldInfo[] fields = type.GetFields();
      foreach (System.Reflection.FieldInfo field in fields)
      {
          field.SetValue(copy, field.GetValue(original));
      }
      return copy as T;
  }

}
