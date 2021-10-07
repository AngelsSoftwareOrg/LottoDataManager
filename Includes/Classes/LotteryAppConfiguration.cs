using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoDataManager.Includes.Classes.ML.FastTree;
using LottoDataManager.Includes.Classes.ML.FastTreeRegression;
using LottoDataManager.Includes.Classes.ML.FastTreeTweedie.DrawResultWinCount;
using LottoDataManager.Includes.Classes.ML.SDCARegression;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Database.DAO.Interface;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Includes.Classes
{
    public class LotteryAppConfiguration
    {
        private Dictionary<String, String> kvpConfig;
        public static String DB_SOURCE_CONFIG_KEY = "db_source_ms_access_path";
        public static String ML_MODEL_CONFIG_KEY = "ml_model_source_path";
        private static LotteryAppConfiguration lotteryAppConfiguration;
        private LotteryAppConfiguration()
        {
            PopulateConfigFileContent();
        }
        public static LotteryAppConfiguration GetInstance()
        {
            if (lotteryAppConfiguration == null)
                lotteryAppConfiguration = new LotteryAppConfiguration();
            return lotteryAppConfiguration;
        }
        public void ReloadConfigContents()
        {
            PopulateConfigFileContent();
        }
        private void PopulateConfigFileContent()
        {
            this.kvpConfig = FileUtils.GetFilePropertiesContent(FileUtils.GetConfigFileFullPath());
        }
        public String DBSourcePath
        {
            set
            {
                try
                {
                    bool isSuccess = TestMainDatabaseSourceConnection(value);
                    if (!isSuccess) throw new Exception(ResourcesUtils.GetMessage("lott_app_config_msg1"));
                    SetConfigValue(DB_SOURCE_CONFIG_KEY, value);
                }
                catch (Exception)
                {
                    throw new Exception(ResourcesUtils.GetMessage("lott_app_config_msg1"));
                }
            }
            get
            {
                return GetConfigValue(DB_SOURCE_CONFIG_KEY);
            }
        }
        public bool TestMainDatabaseSourceConnection(String dbFilePath)
        {
            //Test if the source file can be queried with
            TestingDatabaseSourceFileDao db = TestingDatabaseSourceFileDaoImpl.GetInstance();
            if (String.IsNullOrEmpty(dbFilePath)) return false;
            return db.TestConnection(dbFilePath);
        }
        public bool TestMLMainModelFolderSource(String folderPath)
        {
            if (FastTreePredictor.IsMLModelExisting(folderPath) &&
                LottoMatchCountPredictor.IsMLModelExisting(folderPath) &&
                DrawResultWinCountPredictor.IsMLModelExisting(folderPath) &&
                SDCARegressionPredictor.IsMLModelExisting(folderPath)) return true;
            return false;
        }
        public String MLModelPath
        {
            set
            {
                bool isSuccess = TestMLMainModelFolderSource(value);
                if (!isSuccess) throw new Exception(ResourcesUtils.GetMessage("lott_app_config_msg2"));
                SetConfigValue(ML_MODEL_CONFIG_KEY, value);
            }
            get
            {
                return GetConfigValue(ML_MODEL_CONFIG_KEY);
            }
        }
        public void SaveConfigFile()
        {
            FileUtils.SaveConfigurationFile(this.kvpConfig);
            ReloadConfigContents();
        }
        public bool IsDataSourceComplete()
        {
            return this.TestMainDatabaseSourceConnection(this.DBSourcePath)
                && this.TestMLMainModelFolderSource(this.MLModelPath);
        }
        private void SetConfigValue(String key, String value)
        {
            kvpConfig[key] = value;
        }
        private String GetConfigValue(String key)
        {
            if (kvpConfig.ContainsKey(key))
                return kvpConfig[key];
            return "";
        }
    }
}
