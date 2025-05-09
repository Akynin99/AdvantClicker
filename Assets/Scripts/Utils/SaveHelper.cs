﻿using System.Text;
using AdvantClicker.Components;
using UnityEngine;

namespace AdvantClicker.Utils
{
    public static class SaveHelper
    {
        public static void SaveData(BusinessSaveData saveData)
        {
            int saveId = saveData.SaveId;
            
            PlayerPrefs.SetInt(GetMainSaveKey(saveId), 1);
            
            PlayerPrefs.SetInt(GetLvlSaveKey(saveId), saveData.Level);
            
            PlayerPrefs.SetFloat(GetProgressSaveKey(saveId), saveData.Progress);
            
            string upgradesCountSaveKey = GetUpgradesCountSaveKey(saveId); 
            PlayerPrefs.SetInt(upgradesCountSaveKey, saveData.Upgrades.Length);

            for (int i = 0; i < saveData.Upgrades.Length; i++)
            {
                PlayerPrefs.SetInt(GetUpgradeSaveKey(upgradesCountSaveKey, i), saveData.Upgrades[i] ? 1 : 0);
            }
            
            PlayerPrefs.Save();
        }

        public static bool BusinessSaveExists(int saveId)
        {
            return PlayerPrefs.GetInt(GetMainSaveKey(saveId), 0) > 0;
        }

        public static BusinessSaveData Load(int saveId)
        {
            BusinessSaveData business = new BusinessSaveData();
            business.Level = PlayerPrefs.GetInt(GetLvlSaveKey(saveId), 0);
            business.Progress = PlayerPrefs.GetFloat(GetProgressSaveKey(saveId), 0);

            string upgradesCountSaveKey = GetUpgradesCountSaveKey(saveId);
            int upgradesCount = PlayerPrefs.GetInt(upgradesCountSaveKey, 0);
            business.Upgrades = new bool[upgradesCount];

            for (int i = 0; i < upgradesCount; i++)
            {
                business.Upgrades[i] =  PlayerPrefs.GetInt(GetUpgradeSaveKey(upgradesCountSaveKey, i), 0) > 0;
            }

            return business;
        }

        public static bool WalletSaveExists()
        {
            return PlayerPrefs.GetInt(SaveKeys.WalletSaveKey, -1) >= 0;
        }

        public static int LoadWalletBalance()
        {
            return PlayerPrefs.GetInt(SaveKeys.WalletSaveKey);
        }

        public static void SaveWalletBalance(int balance)
        {
            PlayerPrefs.SetInt(SaveKeys.WalletSaveKey, balance);
            PlayerPrefs.Save();
        }
        
        private static string GetMainSaveKey(int saveId)
        {
            return $"{SaveKeys.MainSaveKey}{saveId}";
        }

        private static string GetLvlSaveKey(int saveId)
        {
            return $"{SaveKeys.LevelSaveKey}{saveId}";
        }
        
        private static string GetProgressSaveKey(int saveId)
        {
            return $"{SaveKeys.ProgressSaveKey}{saveId}";
        }
        
        private static string GetUpgradesCountSaveKey(int saveId)
        {
            return $"{SaveKeys.UpgradesCountSaveKey}{saveId}";
        }
        
        private static string GetUpgradeSaveKey(string upgradesCountSaveKey, int upgradeId)
        {
            return $"{upgradesCountSaveKey}{SaveKeys.UpgradeSaveKey}{upgradeId}";
        }        
    }
}