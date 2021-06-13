using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
[AddComponentMenu("GamePlay/Portals")]
public struct PortalPathComponent: IComponentData
{
	public float3 directionVector;
}