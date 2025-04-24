using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdvantClicker.Config
{
    // ScriptableObject for configuring names of businesses and upgrades
    [CreateAssetMenu(fileName = "NamesConfig", menuName = "Config/NamesConfig")]
    public class NamesConfig : ScriptableObject
    {
        [SerializeField] private IdNamePair[] names;
        
        [Serializable]
        private struct IdNamePair
        {
            public int Id;
            public string Name;
        }

        private void OnValidate()
        {
            if (names == null) return;

            var idSet = new HashSet<int>();
            var duplicates = new List<int>();
            
            foreach (var pair in names)
            {
                
                if (!idSet.Add(pair.Id) && !duplicates.Contains(pair.Id))
                {
                    duplicates.Add(pair.Id);
                }
            }
            
            if (duplicates.Count > 0)
            {
                Debug.LogError($"<color=red>Duplicate IDs found:</color> {string.Join(", ", duplicates)}", this);
            }
        }

        public string GetName(int id)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Id != id) continue;

                return names[i].Name;
            }
            
            Debug.LogError("Name not found!");
            return "no name";
        }
    }
}