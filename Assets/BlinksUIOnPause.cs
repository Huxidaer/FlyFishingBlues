using UnityEngine;

public class BlinksUIOnPause : MonoBehaviour
{
    public float blinkDuration = 1f;  // ��˸������ʱ��
    public float minAlpha = 0f;  // ��С͸����
    public float maxAlpha = 1f;  // ���͸����

    private CanvasGroup canvasGroup;  // CanvasGroup���
    private float timer = 0f;

    void Start()
    {
        // ��ȡCanvasGroup���
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("δ���ҵ�CanvasGroup������뽫�˽ű����ӵ�һ������CanvasGroup��UI�����ϡ�");
        }
    }

    void Update()
    {
        if (canvasGroup != null)
        {
            // ʹ��UnscaledDeltaTime�Բ���Time.timeScale��Ӱ��
            timer += Time.unscaledDeltaTime;

            // ����͸���ȵı仯 (0-1�Ľ���ѭ��)
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(timer / blinkDuration, 1f));

            // ����CanvasGroup��Alphaֵ
            canvasGroup.alpha = alpha;
        }
    }
}
