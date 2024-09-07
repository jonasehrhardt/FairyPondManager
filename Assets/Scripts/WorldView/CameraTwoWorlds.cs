using Assets.Scripts.Structs;
using AYellowpaper.SerializedCollections;
using TMPro.EditorUtilities;
using UnityEngine;

namespace WorldView
{
    public class CameraTwoWorlds : TwoWorldsEntity
    {
        [SerializeField] private SerializedDictionary<TwoWorldsGlobalObserver.state, LayerMask> _masks;
        [SerializeField] private new Camera _camera;

        public void SetCullingMask(LayerMask mask)
            => _camera.cullingMask = mask;

        public void SetMask(TwoWorldsGlobalObserver.state state)
            => SetCullingMask(_masks[state]);

        protected override void OnEnable()
        {
            base.OnEnable();
            TwoWorldsGlobalObserver.Instance.onWorldChange.AddListener(SetMask);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            TwoWorldsGlobalObserver.Instance.onWorldChange.RemoveListener(SetMask);
        }
    }
}
