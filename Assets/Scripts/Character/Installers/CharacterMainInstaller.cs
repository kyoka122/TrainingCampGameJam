using UnityEngine;
using Zenject;
using Character.JumpLogics;

namespace Character.Installers
{
    public class CharacterMainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IJumpLogic>()
                .To<PhysicsJumpLogic>()
                .FromNew()
                .AsTransient();
        }
    }
}