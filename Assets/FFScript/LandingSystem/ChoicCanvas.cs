using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class ChoicCanvas : MonoBehaviour
{
    public NPCConversation Conversation;
    public Image CameraImage;
    public Vector3 targetPosition; // Ŀ��λ��
    public Vector2 targetSizeDelta; // Ŀ���С��ʹ�� Size Delta��
    public float duration = 1.0f; // ��������ʱ��
    public Ease easeType = Ease.InOutQuad; // ������������

    public void ControllImageVisiablity()//diaglue��������������
    {
     

        CameraImage.gameObject.SetActive(true);
 
    
    }
    public void ConrtolImageSize()
    { 
    RectTransform RectImage=CameraImage.GetComponent<RectTransform>();
        Vector3 targetLocalPosition = RectImage.parent.TransformPoint(targetPosition);
        RectImage.DOMove(targetLocalPosition, duration).SetEase(easeType);
       RectImage.DOScale(targetSizeDelta, duration).SetEase(easeType);
    }
   
    private void Start()
    {
        ConversationManager.Instance.StartConversation(Conversation);
    }
}
