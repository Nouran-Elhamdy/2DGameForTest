using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Test.Manager
{
    public abstract class Manager : MonoBehaviour
    {
        #region Props

        private static Dictionary<Type, Manager> m_Managers;
        private static Dictionary<Type, Manager> Managers
        {
            get
            {
                if (m_Managers == null)
                    m_Managers = new Dictionary<Type, Manager>();
                return m_Managers;
            }
        }

        private static BowManager m_BowManager;
        public static BowManager BowManager
        {
            get
            {
                if (!m_BowManager)
                    m_BowManager = GetManager<BowManager>();
                return m_BowManager;
            }
        }

        private static BallPoolManager m_BallPoolManager;
        public static BallPoolManager PoolManager
        {
            get
            {
                if (!m_BallPoolManager)
                    m_BallPoolManager = GetManager<BallPoolManager>();
                return m_BallPoolManager;
            }
        }
        #endregion

        #region Unity Calls

        public virtual void Awake()
        {
            if (!Managers.ContainsKey(this.GetType()))
                Managers.Add(this.GetType(), this);
        }
        public virtual void OnDestroy()
        {
            if (Managers.ContainsKey(this.GetType()))
            {
                Managers[this.GetType()] = null;
                Managers.Remove(this.GetType());
            }
            ClearAllStaticReferences(GetType(), GetType());
        }

        #endregion

        #region Private Methods
        private static void ClearAllStaticReferences(Type type, Type compareType)
        {
            var data = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var fieldInfo in data)
            {
                if (fieldInfo.FieldType != compareType) continue;
                fieldInfo.SetValue(type, null);
            }

            if (type.BaseType != null)
            {
                ClearAllStaticReferences(type.BaseType, compareType);
            }
        }
       
        private static T GetManager<T>()
        {
            if (m_Managers.ContainsKey(typeof(T)))
                return (T)Convert.ChangeType(m_Managers[typeof(T)], typeof(T));
            return (T)Convert.ChangeType(null, typeof(T));
        }
        #endregion
    }
}