from Backend.loot.loot_roller import LootRoller

def test_loot_pity_trigger():
    res = LootRoller.roll_drop(0.99, 50)
    assert res["rarity"] == "MYTHIC"
    assert res["pity_triggered"] is True
