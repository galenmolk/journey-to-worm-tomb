using System;
using UnityEngine;
using WormTomb.General;

namespace WormTomb.UI
{
    public class LevelSelectController : MonoBehaviour
    {
        [SerializeField] private Level[] levels;

        [SerializeField] private Transform levelButtonParent;
        [SerializeField] private LevelButton levelButtonPrefab;
        
        private void Start()
        {
            CreateAllLevelButtons();
        }
        
        private void CreateAllLevelButtons()
        {
            for (int i = 0, length = levels.Length; i < length; i++)
            {
                var level = levels[i];
                
                // True if marked as Missing in inspector.
                if (level == null)
                    continue;
                
                level.SetIndex(i);
                LevelButton.Make(levelButtonPrefab, level, levelButtonParent);
            }
        }
    }
}
