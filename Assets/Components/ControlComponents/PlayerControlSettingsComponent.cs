using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerControlSettingsComponent : IComponentData
{
	public KeyCode jumpKey;
	public int maxJumpsEnabled;
	public int currentJumpsEnabled;
	public float jumpForce;
}
