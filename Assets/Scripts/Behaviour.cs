using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Behaviour : MonoBehaviour
{
    [SerializeField] private Animator[] _animator;

    [HideInInspector] public Rigidbody2D _rb;
    private BoxCollider2D _box;
    [SerializeField] private float jumpAmount;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _extender;
    [SerializeField] private int _flyingSpeed;
    [SerializeField] private GameObject _retry;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GameObject _titleScreen;
    private Arrow _data;
    private Vector2 _jumpDirection;
    private int _temp;
    //powerups
    public int Platforms = 3;
    public int MaxPlatforms = 3;
    public float SecondsToFly = 5;
    public float SecondsToFreeze = 5;
    public bool isFlying = false;
    //save data
    public int StgSize;
    public int Luck = 0;
    public int PowerLevel = 0;
    public bool Skin1 = false;
    public bool Skin2 = false;
    public bool Skin3 = false;
    public bool Skin4 = false;
    public bool Map1 = false;
    public bool Map2 = false;
    public bool Map3 = false;
    public int CurrentSkin;
    public int CurrentMap;
    [SerializeField] private GameObject[] _skins;
    public int Coins = 0;
    public int CoinsInRound = 0;
    public int Score = 0;
    public int Highscore = 0;
    private PlayerData data;
    private float _xpos;
    private float _elapsed;
    public bool HasJumped = false;
    public float FollowX = 0;
    public int PlatformsPassed = 0;
    private void Start()
    {
        //_animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _data = _arrow.GetComponent<Arrow>();
        _box = GetComponent<BoxCollider2D>();
        LoadData();
    }

    public void LoadData()
    {
        data = SaveGame.LoadPlayer();
        if(data != null)
        {
            Skin1 = data._skin1;
            Skin2 = data._skin2;
            Skin3 = data._skin3;
            Map1 = data._map1;
            Coins = data.coins;
            Highscore = data.highscore;
            CurrentSkin = data.currentSkin;
            CurrentMap = data.currentMap;
            SkinUpdate();
            Luck = data.luck;
            PowerLevel = data.powerLevel;
            StgSize = data.stgSize;
            _levelManager.StageSize = StgSize;
        }
    }

    private void Update()
    {
        if (isFlying)
        {
            _rb.velocity = new Vector2(0, _flyingSpeed);
            _elapsed += Time.deltaTime;
            if(PlatformsPassed < SecondsToFly * 6)
            {
                if(transform.position.x > FollowX) transform.Translate(Vector2.left * _flyingSpeed/2 * Time.deltaTime);
                if (transform.position.x < FollowX) transform.Translate(Vector2.right * _flyingSpeed/2 * Time.deltaTime);
            }
            else StartCoroutine(FlyOff());

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && _titleScreen.active==false)
        {
            ResAnims();
            _animator[CurrentSkin].SetTrigger("jump");
        }
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && (isGrounded() && _titleScreen.active == false))
            {
                ResAnims();
                _animator[CurrentSkin].SetTrigger("jump");
            }
        }    
        if (Platforms > 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(new Vector2(0, transform.position.y), new Vector2(15, 18), 0);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Platform" && Platforms > 0 && hitCollider.transform.position.y > transform.position.y)
                {
                    hitCollider.gameObject.GetComponent<Platform>().Enlarge();
                    Platforms--;
                }
            }
        }
        if ((int)(transform.position.y + 3.5f) / 2 > _temp)
            _temp = (int)(transform.position.y + 3.5f) / 2;
        Score = _temp;
        if (Score > Highscore)
        {
            Highscore = Score;
            if (data != null)
                data.highscore = Score;
        }
        //change skins
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentSkin < _skins.Length-1) CurrentSkin++;
            else CurrentSkin = 0;
            SkinUpdate();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CurrentSkin > 0) CurrentSkin--;
            else CurrentSkin = _skins.Length-1;
            SkinUpdate();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
            SaveGame.Delete();
    }

    public void SkinUpdate()
    {
        for (int i = 0; i < _skins.Length; i++)
            if (i != CurrentSkin) _skins[i].SetActive(false);
            else _skins[i].SetActive(true);
    }

    public void FlyOn()
    {
        isFlying = true;
    }

    public void SavePlayer()
    {
        SaveGame.SavePlayer(this);
        Debug.Log("Saved Player");
    }


    public void ResAnims()
    {
        Debug.Log(CurrentSkin);
        _animator[CurrentSkin].ResetTrigger("prop");
        _animator[CurrentSkin].ResetTrigger("over");
        _animator[CurrentSkin].ResetTrigger("jump");
    }

    public void Jump()
    {
        _jumpDirection = new Vector2(_data.getpos().x - transform.position.x, _data.getpos().y - transform.position.y);
        if (_rb.velocity.y == 0)
        {
            Sounds.PlaySound("jump");
            _rb.AddForce(_jumpDirection * jumpAmount, ForceMode2D.Impulse);
            HasJumped = true;
        }
    }
    public bool isGrounded()
    {
        float extraHeight = 0.5f;
        RaycastHit2D hit = Physics2D.BoxCast(_box.bounds.center, _box.bounds.size, 0f, Vector2.down, extraHeight, LayerMask.GetMask("Platform"));
        return (hit.collider != null && _rb.velocity.y == 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Sounds.PlaySound("die");
            _arrow.SetActive(false);
            SaveGame.SavePlayer(this);
            StartCoroutine(Die());
        }
        /*
        if (other.tag == "Platform" && isFlying && _elapsed > SecondsToFly)
            if (Mathf.Abs(other.transform.position.x-transform.position.x)<0.0001f)
                StartCoroutine(FlyOff());
        */
        if (other.tag == "Boost" || other.tag == "Powerup")
            Sounds.PlaySound("powerup");
    }

    public void Fly()
    {
        PlatformsPassed = 0;
        ResAnims();
        _animator[CurrentSkin].SetTrigger("prop");
        _elapsed = 0f;
    }

    public void SpawnExtender()
    {
        Instantiate(_extender, new Vector2(0, transform.position.y), Quaternion.identity);
    }

    public void AddCoins()
    {
        Coins += CoinsInRound;
        CoinsInRound = 0;
        SaveGame.SavePlayer(this);
    }

    public void AddDblCoins()
    {
        Coins += CoinsInRound*2;
        CoinsInRound = 0;
        SaveGame.SavePlayer(this);
    }

    private IEnumerator FlyOff()
    {
        yield return new WaitForSeconds(0.2f);
        _animator[CurrentSkin].SetTrigger("over");
        isFlying = false;
        _rb.velocity = new Vector2(0, 0);
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        _retry.GetComponent<TitleScreen>().Death();
    }
}
