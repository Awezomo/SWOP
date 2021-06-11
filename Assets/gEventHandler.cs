<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class gEventHandler
{
	public delegate void Log(string message);

	private static Log logger;
	public static Log Logger
	{
		get { return logger; }
		set
		{
			Debug.Log("Logger has been set");
			logger = value;
		}
	}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class gEventHandler
{
	public delegate void Log(string message);

	private static Log logger;
	public static Log Logger
	{
		get { return logger; }
		set
		{
			Debug.Log("Logger has been set");
			logger = value;
		}
	}
>>>>>>> 5629f42 (background bug, tutorial completed)
}