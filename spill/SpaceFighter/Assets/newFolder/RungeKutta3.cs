using UnityEngine;
using System.Collections;

public class RungeKutta3 : MonoBehaviour {
    float m = 80f;
    float g = 9.81f;
    private float C = 0.5f;
    private float p = 1.2f;
    public float diameter = 0.5f;
    private float A;
    public bool simulation = false;
    public float startHeight = 25f;
    public float simulationTime = 0f;
    SpriteRenderer mySprite;

    public AudioClip[] audioClips;
    AudioSource speaker;

    public Sprite[] sprites;

    public Vector3[] state;

    public GameObject paracute;


    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        paracute = GameObject.Find("FallP");
        speaker = GameObject.Find("PlayerSounds").GetComponent<AudioSource>();
        ResetCharacter();
    }

    void Update()
    {
        
        CheckInput();
        if (simulation)
        {
            A = Mathf.PI * (diameter / 2) * (diameter / 2);
            state = Rungekutta4(state[0], state[1], Time.deltaTime);
            transform.position = state[0];
            simulationTime += Time.deltaTime;
        }
        
    }

    private Vector3[] Rungekutta4(Vector3 s, Vector3 v, float dt)
    {
        Vector3 s1 = s;
        Vector3 v1 = v;
        Vector3 a1 = Formel(s1, v1, 0);

        Vector3 s2 = (s + 0.5f * v1 * dt);
        Vector3 v2 = (v + 0.5f * a1 * dt);
        Vector3 a2 = Formel(s2, v2, dt / 2);

        Vector3 s3 = (s + 0.5f * v2 * dt);
        Vector3 v3 = (v + 0.5f * a2 * dt);
        Vector3 a3 = Formel(s3, v3, dt / 2);

        Vector3 s4 = (s + v3 * dt);
        Vector3 v4 = (v + a3 * dt);
        Vector3 a4 = Formel(s4, v4, dt);

        Vector3 xf = s + (dt / 6.0f) * (v1 + 2 * v2 + 2 * v3 + v4);
        Vector3 vf = v + (dt / 6.0f) * (a1 + 2 * a2 + 2 * a3 + a4);

        return new Vector3[] { xf, vf };
    }

    private Vector3 Formel(Vector3 s, Vector3 v, float dt)
    {
        float D = (p * v.magnitude * v.magnitude * C * A * 0.5f);
        float Dx = 0f;
        float Dy = 0f;
        float Dz = 0f;

        if (v.magnitude != 0f)
        {
            Dx = -D * (v.x / v.magnitude);
            Dy = -D * (v.y / v.magnitude);
            Dz = -D * (v.z / v.magnitude);
        }
        float G = m * g;
        return new Vector3(Dx / m, (Dy - G) / m, Dz / m);
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown("space"))
        {
            OpenParachute();
        }
        if (Input.GetKeyDown("return"))
        {
            //simulation = true;
            simulation = simulation != true ? true:false ;
        }
    }

    public void OpenParachute()
    {
        //speaker.clip = audioClips[4];
        //speaker.Play();
        diameter = 5f;
        C = 1.4f;
        paracute.SetActive(true);
    }

    public void ChangeSprite(int i)
    {
        mySprite.sprite = sprites[i];
    }

    public void CloseParachute()
    {
        p = 1.2f;
        diameter = 0.5f;
        paracute.SetActive(false);
    }

    public void ResetCharacter()
    {
        CloseParachute();
        transform.position = new Vector3(0f, startHeight, 0f);
        state = new Vector3[] { transform.position, new Vector3(0f, 0f, 0f) };
        simulationTime = 0f;
        ChangeSprite(0);
    }

    public void Jump()
    {
        speaker.clip = audioClips[3];
        speaker.Play();
        ChangeSprite(1);
        simulation = true;
    }

    public void Land()
    {
        simulation = false;
        CloseParachute();
        state[0] = new Vector3(0f,0f,0f);

        if (state[1].y > -7f)
        {
            speaker.clip = audioClips[2];
            speaker.Play();
            ChangeSprite(0);
        }
        else if (state[1].y > -16f)
        {
            speaker.clip = audioClips[1];
            speaker.Play();
            ChangeSprite(2);
        }
        else
        {
            speaker.clip = audioClips[0];
            speaker.Play();
            ChangeSprite(3);
        }
    }
}
