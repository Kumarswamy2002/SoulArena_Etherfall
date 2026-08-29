using System;

namespace SoulArena.Core
{
    public enum EtherElement
    {
        Storm,      // Kael Varyn
        Ember,      // Ryka Voss
        Frost,      // Seren Vale
        Volt,       // Zayn Rheo
        Stone,      // Drakor Thane
        Void,       // Vexa Noir
        Radiance,   // Elara Sol
        Gale,       // Torren Kai
        Crimson,    // Raven Drake
        Nature,     // Nyla Verd
        Psionic,    // Orin Veil
        Solar,      // Solan Ark
        Tidal,      // Mira Tide
        Metal,      // Kade Rourke
        Astral,     // Aeris Quin
        Beast,      // Rokan Fen
        Rift,       // Nox Arden
        Spirit,     // Yuna Rei
        Death,      // Morvan Kreel
        PrimeEther  // Auren Zeth
    }

    public enum FighterRole
    {
        Rushdown,
        Balanced,
        AggressiveBruiser,
        Control,
        SpeedAssassin,
        Tank,
        TricksterAssassin,
        SupportFighter,
        Mobility,
        HighRiskReward,
        Summoner,
        PowerFighter,
        Brawler,
        Ranged,
        CloseCombat,
        SpaceManipulator,
        TechnicalFighter,
        SummonerControl,
        BossAdvanced
    }

    public enum CombatState
    {
        Neutral,
        Moving,
        Dashing,
        Airborne,
        Startup,
        Active,
        Recovery,
        Hitstun,
        Blockstun,
        GuardBroken,
        KnockedDown,
        Parried,
        AirJuggle,
        WallSplat,
        AwakeningActive,
        UltimateExecution,
        Dead
    }

    public enum AttackType
    {
        Light,
        Medium,
        Heavy,
        DashAttack,
        AirAttack,
        Launcher,
        Grab,
        Special1,
        Special2,
        Special3,
        Special4,
        Ultimate,
        CounterAttack,
        BurstEscape
    }

    public enum AttackProperty
    {
        High,
        Mid,
        Low,
        Unblockable,
        Grab,
        Projectile,
        AreaOfEffect,
        ArmorPierce
    }

    public enum HitReactionType
    {
        LightStagger,
        HeavyStagger,
        Crumple,
        LaunchUp,
        Knockback,
        WallBounce,
        GroundBounce,
        HardKnockdown,
        FreezeInPlace,
        VortexPull
    }

    public enum DefenseType
    {
        None,
        StandardBlock,
        PerfectGuard,
        Dodge,
        PerfectDodge,
        ParrySuccess,
        ArmorAbsorb,
        Invulnerable
    }

    public enum CancelWindowType
    {
        None,
        OnHitOnly,
        OnBlockOnly,
        OnWhiff,
        SpecialCancelable,
        SuperCancelable,
        DashCancelable,
        JumpCancelable,
        FreeCancel
    }

    public enum StatusEffectType
    {
        None = 0,
        Burn = 1 << 0,
        Freeze = 1 << 1,
        Shock = 1 << 2,
        Bleed = 1 << 3,
        Silence = 1 << 4,
        Slow = 1 << 5,
        Blind = 1 << 6,
        Root = 1 << 7,
        Weakness = 1 << 8,
        ArmorBreak = 1 << 9,
        EtherDrain = 1 << 10,
        HealingReduction = 1 << 11
    }

    public enum AIDifficulty
    {
        Beginner,
        Normal,
        Advanced,
        Expert,
        Master,
        Grandmaster
    }

    public enum AIPersonality
    {
        Aggressive,
        Defensive,
        Tactical,
        Evasive,
        CounterFighter,
        ComboFighter
    }

    public enum ArenaId
    {
        SkyforgeTemple,
        EmberfallCrater,
        FrostveilSanctuary,
        VerdantRuins,
        IronHarbor,
        RiftObservatory,
        SunkenCitadel,
        GraveCathedral,
        AstralGarden,
        SoulforgeColiseum
    }

    public enum GameModeType
    {
        OneVsOne,
        TwoVsTwo,
        ThreeVsThree,
        FreeForAll,
        Training,
        Casual,
        Ranked,
        Tournament,
        Survival,
        BossBattle,
        StoryMode
    }

    public enum MatchResult
    {
        InProgress,
        Player1Victory,
        Player2Victory,
        Draw,
        TimeOutPlayer1Win,
        TimeOutPlayer2Win,
        DisconnectionForfeit
    }
}
