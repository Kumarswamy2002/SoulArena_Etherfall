from Backend.combat.ether_reactions import EtherReactionEngine

def test_elemental_vaporize():
    res = EtherReactionEngine.resolve_interaction("PYRO", "HYDRO", 100.0)
    assert res["reaction"] == "VAPORIZE"
    assert res["damage"] == 200.0
