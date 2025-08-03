using UnityEngine;

namespace Index.Scripts
{
    public class NoClipHelper : MonoBehaviour
    {
        public static NoClipHelper Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }

        public T[] FindAllObjectsOfType<T>() where T : Object => FindObjectsOfType<T>();
    }
}