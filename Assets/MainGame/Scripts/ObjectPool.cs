using System.Collections.Generic;
using UnityEngine;
using System;

namespace Test.Manager
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "Singltons/Object Pool")]
    public class ObjectPool : ScriptableObject
    {
        #region Public Variables
        public List<ItemToPool> allObjects;     
        public bool isExpand;                   
        public List<BallItem> pooledObjects; 
        [NonSerialized] public Transform spawnManagerTransform;
        #endregion

        #region Public Methods
        public void StartPool()
        {
            pooledObjects = new List<BallItem>();

            foreach (ItemToPool item in allObjects)
            {
                for (int i = 0; i < item.size; i++)
                {
                    BallItem go = Instantiate(item.pool);
                    go.gameObject.SetActive(false);
                    pooledObjects.Add(go);
                    go.transform.SetParent(spawnManagerTransform);
                }
            }
        }
        public BallItem GetPooledObject(Type type)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                int rand = UnityEngine.Random.Range(0, pooledObjects.Count);
                if (pooledObjects[rand].gameObject.activeInHierarchy == false && pooledObjects[rand].GetType() == type)
                {
                    return pooledObjects[rand];
                }
            }
            if (isExpand)
            {
                BallItem[] randomObject = RandomList();
                foreach (BallItem item in randomObject)
                {
                    if (item.GetType() == type)
                    {
                        BallItem go = Instantiate(item);
                        go.gameObject.SetActive(false);
                        pooledObjects.Add(go);
                        return go;
                    }
                }

            }


            return null;
        }

        #endregion

        #region Private Methods
        private BallItem[] RandomList()
        {
            foreach (ItemToPool obj in allObjects)
            {
                pooledObjects.Add(obj.pool);
            }

            BallItem[] randomArray = pooledObjects.ToArray();

            for (int i = 0; i < pooledObjects.Count; i++)
            {
                int k = UnityEngine.Random.Range(0, pooledObjects.Count);
                BallItem temp = randomArray[k];
                randomArray[k] = randomArray[i];
                randomArray[i] = temp;
            }
            return randomArray;

        }
        #endregion

    }

    [System.Serializable]
    public class ItemToPool
    {
        public BallItem pool;
        public int size;
    }
}