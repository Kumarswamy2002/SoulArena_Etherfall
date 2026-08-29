from Backend.analytics.combat_meter import RaidCombatMeter

def test_combat_meter_dps():
    meter = RaidCombatMeter()
    meter.record_event("player_mage", "DAMAGE", 500.0, 1.0)
    meter.record_event("player_mage", "DAMAGE", 500.0, 2.0)
    summary = meter.get_actor_summary("player_mage", 10.0)
    assert summary["total_damage"] == 1000.0
    assert summary["dps"] == 100.0
