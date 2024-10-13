using UnityEngine;

public class DynamicD : MonoBehaviour
{
    // ������Ҫ�����UI����
    public GameObject uiText;
    // ��Ҫ��������A
    public GameObject objectA;  // ����Trigger������A

    private Collider objectACollider;

    private void Start()
    {
        // ȷ��UI�ı�Ĭ�ϴ��ڲ�����״̬
        if (uiText != null)
        {
            uiText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Text object is not assigned!");
        }

        // ��ȡ����A��Collider���
        if (objectA != null)
        {
            objectACollider = objectA.GetComponent<Collider>();

            if (objectACollider == null || !objectACollider.isTrigger)
            {
                Debug.LogError("Object A does not have a Trigger Collider!");
            }
        }
        else
        {
            Debug.LogError("Object A is not assigned!");
        }
    }

    // ������A�Ĵ�����������ʱ����
    private void OnTriggerEnter(Collider other)
    {
        // ����Ƿ�Ϊ�������崥��
        if (other != objectACollider)
        {
            // ����UI
            if (uiText != null)
            {
                uiText.SetActive(true);
                Debug.Log("Object A triggered by another object. UI Activated.");
            }
        }
    }
}
