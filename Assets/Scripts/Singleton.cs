using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
	private static object _lock = new object();
	public static bool IsShuttingDown { get; private set; } = false;

	public static T Instance
	{
		get
		{
			if (IsShuttingDown)
			{
				Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
				return null;
			}

			lock (_lock)
			{
				if (_instance == null)
				{
					_instance = (T)FindObjectOfType(typeof(T));

					if (_instance == null)
					{
						var singletonObject = new GameObject();
						_instance = singletonObject.AddComponent<T>();
						singletonObject.name = $"{typeof(T)} (Singleton)";
					}

					DontDestroyOnLoad(_instance.gameObject);
				}

				return _instance;
			}
		}
	}

	protected virtual void OnApplicationQuit()
	{
		IsShuttingDown = true;
	}

	protected virtual void OnDestroy()
	{
		IsShuttingDown = true;
	}
}
