using UnityEngine;

namespace SingletonSystem
{

	public class Singleton<T> : MonoBehaviour where T : Component
	{
		private static T _instance;

		public void SetInstance(T instance)
		{
			_instance = instance;
			_instance.gameObject.hideFlags = HideFlags.NotEditable;
		}


		public static T Instance
		{
			get
			{

				if (_instance == null)
				{

					//_instance = GameObject.FindObjectOfType<T>();

					if (_instance == null)
					{
						GameObject obj = new GameObject();
						obj.name = typeof(T).Name;
						obj.hideFlags = HideFlags.NotEditable;
						_instance = obj.AddComponent<T>();
					}
				}

				return _instance;
			}
		}



		public static void EnsureCreation()
		{
			if (_instance == null)
			{
				GameObject obj = new GameObject();
				obj.name = typeof(T).Name;
				_instance = obj.AddComponent<T>();

				obj.hideFlags = HideFlags.NotEditable;
				_instance.hideFlags = HideFlags.NotEditable;
			}
		}
	}


	public class SingletonPersistent<T> : MonoBehaviour where T : Component
	{
		private static T _instance;


		public static T Instance
		{
			get
			{
				EnsureCreation();

				return _instance;
			}
		}

		protected virtual void Awake()
		{
			T component = GetComponent<T>();


			if (_instance == null)
			{
				_instance = component;

				gameObject.hideFlags = HideFlags.NotEditable;
				_instance.hideFlags = HideFlags.NotEditable;
			}



			if (_instance != component)
			{
				Destroy(gameObject);
			}



		}




		public static void EnsureCreation()
		{
			if (_instance == null)
			{
				GameObject obj = new GameObject();
				obj.name = typeof(T).Name;
				_instance = obj.AddComponent<T>();

				obj.hideFlags = HideFlags.NotEditable;
				_instance.hideFlags = HideFlags.NotEditable;

				DontDestroyOnLoad(obj);
			}
		}









	}


}

