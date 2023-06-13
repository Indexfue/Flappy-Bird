using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int _capacity;
        [SerializeField] private GameObject _container;

        private List<GameObject> _objects = new List<GameObject>();

        protected void Initializate(GameObject prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject obj = Instantiate(prefab, _container.transform);
                obj.SetActive(false);
                _objects.Add(obj);
            }
        }
        
        protected bool TryGetObject(out GameObject obj)
        {
            obj = _objects.First(x => x.activeSelf == false);

            return obj != null;
        }
    }
}
