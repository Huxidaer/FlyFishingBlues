using System.Collections;
using UnityEngine;

public class DynamicInputSpace : MonoBehaviour
{
    private CanvasGroup canvasGroup;  // �Զ���ȡCanvasGroup���
    public float fadeInDuration = 2f;  // UI�����ֵ�ʱ��
    public float blinkDuration = 1f;   // UI��˸��ʱ�䣨һ��͸���ȱ仯��ʱ�䣩
    public float maxAlpha = 0.7f;      // ��˸ʱ�����͸����
    public float fadeOutDuration = 1.5f; // ��Ұ�ס�ո�ʱUI������ʱ��

    private bool spaceHeld = false;    // �ո���Ƿ񱻰�ס
    private Coroutine blinkCoroutine;  // ���ڿ�����˸Э��

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();  // �Զ���ȡCanvasGroup���
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup���δ�ҵ�����ȷ����UI�����ϴ���CanvasGroup�����");
            return;
        }

        canvasGroup.alpha = 0f;  // ��ʼ͸������Ϊ0
        StartCoroutine(FadeIn());  // ��ʼUI�Ľ���
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceHeld = true;  // ��¼�ո��������
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);  // ֹͣ��˸
            }
            StartCoroutine(FadeOut());  // ��ʼ����
        }
    }

    // ����Ч��
    IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeInDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeInDuration);  // ��0%��100%͸����
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;  // ȷ��͸����Ϊ100%
        StartCoroutine(Blink());  // ��ʼ��˸
    }

    // ��˸Ч��
    IEnumerator Blink()
    {
        while (!spaceHeld)  // ֻҪ�ո�û��ס��һֱ��˸
        {
            // ���Ե����͸����
            float timer = 0f;
            while (timer < blinkDuration / 2f)
            {
                canvasGroup.alpha = Mathf.Lerp(0f, maxAlpha, timer / (blinkDuration / 2f));
                timer += Time.deltaTime;
                yield return null;
            }

            // ������0͸����
            timer = 0f;
            while (timer < blinkDuration / 2f)
            {
                canvasGroup.alpha = Mathf.Lerp(maxAlpha, 0f, timer / (blinkDuration / 2f));
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }

    // ����Ч��
    IEnumerator FadeOut()
    {
        float timer = 0f;
        while (timer < fadeOutDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeOutDuration);  // ��100%��0%͸����
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;  // ȷ��͸����Ϊ0
    }
}
