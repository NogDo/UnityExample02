using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

namespace FileTestProject
{
    public class CFileTest : MonoBehaviour
    {
        #region public ����
        public Text text;
        public List<PlayerData> playerDatas;
        public List<PlayerData> readFromJson = new List<PlayerData>();
        #endregion

        void Start()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Data Path : ");
            stringBuilder.AppendLine(Application.dataPath);
            stringBuilder.Append("Pers data Path : ");
            stringBuilder.AppendLine(Application.persistentDataPath);
            stringBuilder.Append("Str data Path : ");
            stringBuilder.AppendLine(Application.streamingAssetsPath);

            //string path = Application.dataPath;
            //path += "\n";
            //path += Application.persistentDataPath;
            //path += "\n";
            //path += Application.streamingAssetsPath;

            text.text = stringBuilder.ToString();
        }

        public void Save()
        {
            // ���̺�
            foreach (PlayerData data in playerDatas)
            {
                // �ؽ�Ʈ ������ ����� ��� (���ϸ�, Ȯ���� ����)
                string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";

                // PlayerData�� Json ���ڿ��� ��ȯ JsonUtility ���
                //string json = JsonUtility.ToJson(data);

                // PlayerData�� Json ���ڿ��� ��ȯ NewtonJson ���
                string json = JsonConvert.SerializeObject(data);

                // ���� ��� (���, ����);
                File.WriteAllText(path, json);
            }
        }

        public void Load()
        {
            readFromJson.Clear();

            // �ε�
            string[] names = { "����", "������" };

            //foreach (string name in names)
            //{
            //    string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            //    // ��ȿ�� �˻�
            //    if (File.Exists(path))
            //    {
            //        // ���Ϸκ��� Json�������� ���ڿ��� ������
            //        string json = File.ReadAllText(path);
            //        // Json������ �����͸� �Ľ��Ͽ� PlayerData�ν��Ͻ� ���� �� �� �Ҵ�
            //        readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            //    }
            //}

            // StreamingAssets ���� �ȿ� �ִ� Json ������ ��� �о readFromJson ����Ʈ�� Add �Ͻÿ�.
            // ��Ʈ
            DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

            foreach (FileInfo file in di.GetFiles("*.json"))
            {
                // ��ȿ�� �˻�
                if (file.Exists)
                {
                    // ���Ϸκ��� Json�������� ���ڿ��� ������
                    string json = File.ReadAllText(file.FullName);


                    // Json������ �����͸� �Ľ��Ͽ� PlayerData�ν��Ͻ� ���� �� �� �Ҵ� JsonUtility ���
                    //PlayerData data = JsonUtility.FromJson<PlayerData>(json);
                    //readFromJson.Add(data);

                    // Json������ �����͸� �Ľ��Ͽ� PlayerData�ν��Ͻ� ���� �� �� �Ҵ� NewtonJson ���
                    PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);
                    readFromJson.Add(data);
                }
            }
        }
    }

    // �ٸ� ���·� �����͸� ����ϱ� ���� ����ȭ ������ �ʿ��ϴ�. (������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ ����)
    // ����ȭ�� �����ϸ� PlayerDataŬ������ ���� �ȿ� �ִ� ������ �� �� �ִ�.
    // ���ȼ��� ��������ٴ� ������ �ִ�.
    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int level;
        public float exp;
        public int hp;
        public int attack;
        public int[] items;
        public List<SkillData> skills;
    }

    [System.Serializable]
    public class SkillData
    {
        public int id;
        public int level;
        public EUpgradeType upgrade;
    }

    public enum EUpgradeType
    {
        ATTACK,
        DEFENCE,
        SPEED,
        HP
    }
}
