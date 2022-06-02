using System;
using System.Collections.Generic;
using UnityEngine;
using WormTomb.Utils;

namespace WormTomb.General
{
    public class UpdateManager : MonoBehaviour
    {
        private static List<IUpdatable> RegularUpdatables;
        private static List<IUpdatable> FixedUpdatables;

        private static int regularUpdatableCount;
        private static int fixedUpdatableCount;
        
        public static void AddUpdatable(IUpdatable updatable)
        {
            
            
            if (RegularUpdatables.Contains(updatable))
                return;
            
            RegularUpdatables.Add(updatable);
            regularUpdatableCount = RegularUpdatables.Count;
        }
        
        public static void RemoveUpdatable(IUpdatable updatable)
        {
            RegularUpdatables.Remove(updatable);
            regularUpdatableCount = RegularUpdatables.Count;
        }

        private static void AddRegularUpdatable(IUpdatable updatable)
        {
            
        }
        
        private static void Add
        
        private void Awake()
        {
            GatherUpdatables();
        }

        private void Update()
        {
            if (regularUpdatableCount < 1 || RegularUpdatables == null)
                return;
            
            UpdateComponents();
        }

        private void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        private void GatherUpdatables()
        {
            RegularUpdatables = new List<IUpdatable>();
            regularUpdatableCount = 0;
            
            var allObjects = FindObjectsOfType<GameObject>();
            int objCount = allObjects.Length;
            for (int i = 0; i < objCount; i++)
            {
                if (!allObjects[i].TryGetComponent(out IUpdatable updatable))
                    continue;
                
                if (!updatable.AlwaysUpdate)
                    continue;
                
                Debug.Log("Found Updatable: " + allObjects[i].name);
                RegularUpdatables.Add(updatable);
                regularUpdatableCount++;
            }
        }
        
        private void UpdateComponents()
        {
            for (int i = 0; i < regularUpdatableCount; i++)
                RegularUpdatables[i].ExecuteUpdate();
        }
    }
}
