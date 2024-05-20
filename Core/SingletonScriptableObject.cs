using UnityEngine;

namespace SingletonSystem
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {

        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    T[] asset = Resources.LoadAll<T>("");

                    if (asset == null || asset.Length < 1)
                    {
                        throw new System.Exception("Could not find any" + typeof(T).Name + "instance in the resources");
                    }
                    else if (asset.Length > 1)
                    {
                        Debug.LogWarning("Multiple instances of " + typeof(T).Name + " found in resources");
                    }
                    _instance = asset[0];
                }



                return _instance;
            }
        }


    }

}