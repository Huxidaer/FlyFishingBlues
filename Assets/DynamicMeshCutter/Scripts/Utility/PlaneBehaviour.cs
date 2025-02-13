using System.Collections;
using UnityEngine;

namespace DynamicMeshCutter
{
    public class PlaneBehaviour : CutterBehaviour
    {
        public float DebugPlaneLength = 2;

        public MeshTarget[] targetsToCut;
        public KnifeController KnifeController;
        public GameObject bloodEffectPrefab;
        public Vector3 targetScale = new Vector3(10f, 10f, 10f);
        public GameObject Bucket;

        public void Cut()
        {
            if (targetsToCut != null && targetsToCut.Length > 0)
            {
                foreach (var target in targetsToCut)
                {

                    Cut(target, transform.position, transform.forward, null, OnCreated);
                    Debug.Log("!!!!!!!");
                    Debug.Log($"Cutting target: {target.gameObject.name}");

                }
            }
            else
            {
                Debug.LogWarning("û��ָ��Ҫ���и��Ŀ�����");
            }
        }


        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
            
            Vector3 spawnPosition = info.MeshTarget.transform.position;
            Quaternion spawnRotation = Quaternion.identity; // ������Ҫ������ת
            GameObject bloodEffect = Instantiate(bloodEffectPrefab, spawnPosition, spawnRotation);

            // ����Э�̣��Ŵ�Ѫ��Ч��
            StartCoroutine(ScaleBloodEffect(bloodEffect.transform));
            foreach (var target in cData.CreatedTargets)
            {
                if (target != null)
                {
                    // ��� Grabbable �ű�
                    target.gameObject.AddComponent<Grabbable>();
                     
                }
            }
            Bucket.SetActive(true);
        }
        IEnumerator ScaleBloodEffect(Transform bloodTransform)
        {
            float duration = 1f; // �Ŵ����ʱ��
            float elapsedTime = 0f;
            Vector3 initialScale = Vector3.zero; // ��ʼ��СΪ 0
             // Ŀ���С��������Ҫ����

            // ��Ѫ��Ч���ĳ�ʼ��С����Ϊ 0
            bloodTransform.localScale = initialScale;

            // �Ŵ�Ѫ��Ч��
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                bloodTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);
                yield return null;
            }
            KnifeController.deleteTHeknife();
        }
    }
}
