using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct PlayerSpeedComponent : IComponentData
{
	public float maxHorizontalSpeed;
}