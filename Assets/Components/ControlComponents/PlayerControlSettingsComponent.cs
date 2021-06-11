<<<<<<< HEAD
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
=======
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
>>>>>>> 5629f42 (background bug, tutorial completed)
