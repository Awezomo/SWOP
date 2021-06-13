using UnityEngine;
using Unity.Entities;
/// <summary>
///	This component is used to tag a collision-capable entity which enables the jumping of moving entities. 
/// </summary>
[GenerateAuthoringComponent]
public struct JumpEnablingComponent : IComponentData 
{
	public float dampening;
}