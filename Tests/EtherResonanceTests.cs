using System;
using SoulArena.Core;
using SoulArena.Ether;
using SoulArena.Resonance;
using SoulArena.Awakening;
using SoulArena.Characters;
using SoulArena.Arenas;

namespace SoulArena.Tests
{
    public static class EtherResonanceTests
    {
        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception($"EtherResonanceTest Failed: {message}");
            }
        }

        public static void RunAllEtherTests()
        {
            TestEtherConsumption();
            TestEtherBurnoutTrigger();
            TestResonanceAccumulationAndAwakening();
        }

        public static void TestEtherConsumption()
        {
            var ether = new EtherResource(1, 100.0f);
            ether.AddEther(50.0f); // 100 max

            bool success = ether.TryConsume(30.0f);
            Assert(success, "Ether consumption should succeed when sufficient Ether exists.");
            Assert(Math.Abs(ether.CurrentEther - 70.0f) < 0.001f, $"Current Ether should be 70. Got: {ether.CurrentEther}");
        }

        public static void TestEtherBurnoutTrigger()
        {
            var ether = new EtherResource(1, 100.0f);
            // Drain completely
            ether.TryConsume(ether.CurrentEther);

            Assert(ether.IsInBurnout, "Draining Ether to zero must trigger Burnout lockout.");
            Assert(!ether.TryConsume(5.0f), "Cannot consume Ether during Burnout.");
        }

        public static void TestResonanceAccumulationAndAwakening()
        {
            var res = new ResonanceSystem(1, 100.0f);
            var awk = new AwakeningController(1, EtherElement.Storm);

            res.AddResonance(100.0f);
            Assert(res.IsAwakeningReady, "Resonance at 100 should make Awakening ready.");

            bool activated = awk.TryActivateAwakening(res);
            Assert(activated, "Awakening should successfully activate.");
            Assert(awk.IsAwakened, "AwakeningController should report active.");
            Assert(res.CurrentResonance == 0.0f, "Resonance should be consumed upon Awakening.");
        }
    }

    public static class CharacterRosterTests
    {
        public static void RunAllRosterTests()
        {
            var fighters = FighterRoster.GetAllFighters();
            if (fighters.Count != 20)
            {
                throw new Exception($"Roster must have exactly 20 fighters. Found: {fighters.Count}");
            }

            foreach (var fighter in fighters)
            {
                if (string.IsNullOrEmpty(fighter.FighterId) || string.IsNullOrEmpty(fighter.Name))
                {
                    throw new Exception($"Fighter definition invalid for: {fighter.FighterId}");
                }

                var instance = FighterRoster.CreateFighterInstance(1, fighter.FighterId);
                if (instance.Moves.GetMove($"{fighter.FighterId}_light1") == null)
                {
                    throw new Exception($"Fighter {fighter.FighterId} is missing basic attack chain move!");
                }
                if (instance.Abilities.GetAbility($"{fighter.FighterId}_special1") == null)
                {
                    throw new Exception($"Fighter {fighter.FighterId} is missing Special1 ability!");
                }
            }

            var arenas = ArenaFactory.GetAllArenas();
            if (arenas.Count != 10)
            {
                throw new Exception($"Arena factory must have exactly 10 arenas. Found: {arenas.Count}");
            }
        }
    }
}
