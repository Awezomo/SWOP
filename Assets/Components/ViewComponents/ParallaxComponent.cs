using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct ParallaxComponent : IComponentData
{
	public float z;
	public static float PlayerPositionX;
}

