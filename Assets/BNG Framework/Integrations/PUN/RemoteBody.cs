using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RemoteBody : MonoBehaviour
{
    [SerializeField]
    private GameObject _head;

    [SerializeField]
    private GameObject _body;

    [SerializeField]
    private float _headToBodyGap = .75f;

    private PhotonView _view;
    // Start is called before the first frame update
    void Start()
    {
        _view = GetComponent<PhotonView>();
        if (!_view.IsMine)
        {
            _body.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!_view.IsMine)
        {
            _body.transform.position = new Vector3(_head.transform.position.x, _head.transform.position.y - _headToBodyGap, _head.transform.position.z);
            var euler = _head.transform.rotation.eulerAngles;
            _body.transform.rotation = Quaternion.Euler(0, euler.y, 0);
        }
    }
}
