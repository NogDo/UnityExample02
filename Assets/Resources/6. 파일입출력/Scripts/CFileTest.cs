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
        #region public 변수
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
            // 세이브
            foreach (PlayerData data in playerDatas)
            {
                // 텍스트 파일을 출력할 경로 (파일명, 확장자 포함)
                string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";

                // PlayerData를 Json 문자열로 변환 JsonUtility 사용
                //string json = JsonUtility.ToJson(data);

                // PlayerData를 Json 문자열로 변환 NewtonJson 사용
                string json = JsonConvert.SerializeObject(data);

                // 파일 출력 (경로, 내용);
                File.WriteAllText(path, json);
            }
        }

        public void Load()
        {
            readFromJson.Clear();

            // 로드
            string[] names = { "전사", "마법사" };

            //foreach (string name in names)
            //{
            //    string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            //    // 유효성 검사
            //    if (File.Exists(path))
            //    {
            //        // 파일로부터 Json포맷으로 문자열을 가져옴
            //        string json = File.ReadAllText(path);
            //        // Json포맷의 데이터를 파싱하여 PlayerData인스턴스 생성 후 값 할당
            //        readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            //    }
            //}

            // StreamingAssets 폴더 안에 있는 Json 파일을 모두 읽어서 readFromJson 리스트에 Add 하시오.
            // 힌트
            DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

            foreach (FileInfo file in di.GetFiles("*.json"))
            {
                // 유효성 검사
                if (file.Exists)
                {
                    // 파일로부터 Json포맷으로 문자열을 가져옴
                    string json = File.ReadAllText(file.FullName);


                    // Json포맷의 데이터를 파싱하여 PlayerData인스턴스 생성 후 값 할당 JsonUtility 사용
                    //PlayerData data = JsonUtility.FromJson<PlayerData>(json);
                    //readFromJson.Add(data);

                    // Json포맷의 데이터를 파싱하여 PlayerData인스턴스 생성 후 값 할당 NewtonJson 사용
                    PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);
                    readFromJson.Add(data);
                }
            }
        }
    }

    // 다른 형태로 데이터를 취급하기 위해 직렬화 과정이 필요하다. (데이터 호환성이 필요한 데이터 객체이기 때문에 직렬화 진행)
    // 직렬화를 진행하면 PlayerData클래스를 몰라도 안에 있는 정보를 알 수 있다.
    // 보안성이 취약해진다는 단점이 있다.
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
