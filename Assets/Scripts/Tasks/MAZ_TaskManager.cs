using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Test
{
    public class MAZ_TaskManager : MonoBehaviour
    {
        private static MAZ_TaskManager m_instance;

        [SerializeField] private MAZ_TaskData m_data;
        [SerializeField] private MAZ_TaskObjective currentObjective;
        [SerializeField] private string currentAreaID;
        [SerializeField] private string currentObjectID;
        [SerializeField] protected bool isCompleted = false;
        [SerializeField] List<MAZ_TaskObjective> listObjectives = new List<MAZ_TaskObjective>();
       
        [SerializeField] private MAZ_Metrics m_metrics;
        [SerializeField] private int m_correct = 0;
        [SerializeField] private int m_incorrect = 0;
        [SerializeField] private float m_timeSpent = 0;

        public static MAZ_TaskManager Instance
        {
            get
            {
                return m_instance;
            }
        }

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            string datastring = System.IO.File.ReadAllText(Application.dataPath + "/template.json");
            m_data = (MAZ_TaskData)JsonUtility.FromJson<MAZ_TaskData>(datastring);
            //listObjectives = m_data.Objectives;
            listObjectives = new List<MAZ_TaskObjective>(m_data.Objectives);



            if (listObjectives[0] == null)
            {
                Debug.Log("There's no more data stored");
            }
            else if (listObjectives[0] != null && !isCompleted)
            {
                currentObjective = listObjectives[0];
                currentAreaID = currentObjective.AreaID;
                currentObjectID = currentObjective.ObjectID;
            }


        }


        public void CheckObjective(String _areaID, String _objectID)
        {

            if (_areaID.Equals(currentAreaID) && _objectID.Equals(currentObjectID))
            {
                m_correct++;
                listObjectives.RemoveAt(0);
                MAZ_AudioManager.Instance.correctSound();
            }
            else
            {
                m_incorrect++;
                MAZ_AudioManager.Instance.incorrectSound();  
            }
            m_metrics.setCompletedObjective(m_correct);
            m_metrics.setFailedObjective(m_incorrect);

        }

        public void Update()
        {
            if(listObjectives.Count > 0)
            {
                currentObjective = listObjectives[0];
                currentAreaID = currentObjective.AreaID;
                currentObjectID = currentObjective.ObjectID;
            }
            
            else
            {
                Debug.Log("Hemos terminado");
                isCompleted = true;
                m_metrics.setTime(m_timeSpent += Time.deltaTime);
                string metricsToJson = JsonUtility.ToJson(m_metrics);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/metrics.json", metricsToJson);
                Debug.Log(Application.persistentDataPath);
            }
        }
    }
  
}

