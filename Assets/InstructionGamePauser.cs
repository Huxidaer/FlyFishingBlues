using UnityEngine;

public class InstructionGamePauser : MonoBehaviour
{
    private bool isPaused = false;  // ���ڼ����Ϸ�Ƿ�����ͣ
    public KeyCode resumeKey;  // ��������������ָ���ָ���Ϸ�İ���
    public GameObject pauseUI;  // ��������������ָ����ͣʱ��ʾ��UI���

    void OnTriggerEnter(Collider other)
    {
        // ����⵽��������ײʱ������UI�������ͣ��Ϸ
        if (!isPaused)
        {
            pauseUI.SetActive(true);
            PauseGame();
        }
    }

    void PauseGame()
    {
        // ������Ϸ��ͣ
        Time.timeScale = 0f;  // ��ͣ��Ϸ��0Ϊ��ͣ��1Ϊ�����ٶ�
        isPaused = true;
        Debug.Log("Game Paused");
    }

    void ResumeGame()
    {
        // �ָ���Ϸ
        Time.timeScale = 1f;  // �ָ���Ϸ
        isPaused = false;
        Debug.Log("Game Resumed");

        // ��UI���ʧ��
        pauseUI.SetActive(false);

        // �������GameObjectʧ��
        gameObject.SetActive(false);
    }

    void Update()
    {
        // �������Ƿ�ͬʱ���¿ո����ָ����resumeKey�Իָ���Ϸ
        if (isPaused && Input.GetKey(KeyCode.Space) && Input.GetKeyDown(resumeKey))
        {
            ResumeGame();
        }
    }
}