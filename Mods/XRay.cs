using Index.Scripts;
using UnityEngine;

namespace Index.Mods
{
    [IndexMod("XRay", "A mod that allows you to see other players through walls.", "XRay", 15)]
    class XRay : ModHandler
    {
        public static XRay instance;

        public override void Start()
        {
            base.Start();
            instance = this;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isLocal && !rig.skeleton.enabled)
                {
                    rig.skeleton.enabled = true;
                    rig.skeleton.renderer.enabled = true;
                    rig.skeleton.renderer.material.shader = Shader.Find("GUI/Text Shader");
                    rig.skeleton.renderer.material.color = rig.playerColor;
                }
            }
        }

        public override void OnModEnabled()
        {
            base.OnModEnabled();
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isLocal)
                {
                    rig.skeleton.enabled = true;
                    rig.skeleton.renderer.enabled = true;
                    rig.skeleton.renderer.material.shader = Shader.Find("GUI/Text Shader");
                    rig.skeleton.renderer.material.color = rig.playerColor;
                }
            }
        }

        public override void OnModDisabled()
        {
            base.OnModDisabled();
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                rig.skeleton.renderer.enabled = false;
                rig.skeleton.renderer.material.shader = Shader.Find("GorillaTag/UberShader");
                rig.skeleton.renderer.material.color = rig.playerColor;
            }
        }
    }
}