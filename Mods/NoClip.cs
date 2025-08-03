using Index.Scripts;
using System;
using UnityEngine;

namespace Index.Mods
{
    [IndexMod("No-Clip", "Makes you non-collidable.", "NoClip", 9)]
    class NoClip : ModHandler
    {
        public static NoClip instance;

        public override void Start()
        {
            base.Start();
            instance = this;
            if (NoClipHelper.Instance == null)
            {
                GameObject helperObject = new GameObject("NoClipHelper");
                helperObject.AddComponent<NoClipHelper>();
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (MeshCollider col in NoClipHelper.Instance.FindAllObjectsOfType<MeshCollider>())
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat >= 0.5 || ControllerInputPoller.instance.rightControllerIndexFloat >= 0.5)
                    col.enabled = false;
                else
                    col.enabled = true;
            }

        }

        public override void OnModDisabled()
        {
            base.OnModDisabled();
            Platforms.instance.OnModDisabled();
            foreach (MeshCollider meshCollider in NoClipHelper.Instance.FindAllObjectsOfType<MeshCollider>())
                meshCollider.enabled = true;
        }

        public override void OnModEnabled()
        {
            Platforms.instance.OnModEnabled();
            base.OnModEnabled();
        }
    }
}