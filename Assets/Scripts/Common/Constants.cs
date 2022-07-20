using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common
{
    public static class Constants
    {
        public const string TagPlayer = "Player";
        public const string TagCreep = "Creep";
        public const string TagShuriken = "Shuriken";
        public const string TagBoss = "Boss";
        public const string TagFireball = "Fireball";

        // Goblin's triggers
        public const string GoblinTriggerTakeHit = "TakeHit";
        public const string GoblinTriggerAttack = "Attack";
        public const string GoblinTriggerDie = "Die";


        // Skeleton's triggers
        public const string SkeletonTriggerTakeHit = "TakeHit";
        public const string SkeletonTriggerAttack = "Attack";
        public const string SkeletonTriggerDeath = "Death";

        // FlyingEye's triggers
        public const string FlyingEyeTriggerTakeHit = "TakeHit";
        public const string FlyingEyeTriggerDeath = "Death";

        // Creep Damage
        public const int GoblinDmg = 12;
        public const int FlyingEyeDmg = 10;
        public const int SkeletonDmg = 12;
        public const int MushroomDmg = 30;
        public const int TrapDmg = 8;

        //Boss Damage
        public const int BossDmgAttack = 20;
        public const int BossEnrageAttack = 30;
        public const int BossJumpAttack = 30;
        public const int BossFireBlastingAttack = 30;
        public const int BossFireBallsAttack = 30;

    }
}
