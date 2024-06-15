using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Resource")]
    public class ResourceData : ScriptableObject
    {
        public Resource Resource;
        public string name;
        public float amount;
    }
}