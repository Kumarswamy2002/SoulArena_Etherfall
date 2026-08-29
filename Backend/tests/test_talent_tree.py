from Backend.talents.talent_tree import TalentTreeSystem

def test_talent_unlock_prereq():
    unlocked = {"tier1_power"}
    assert TalentTreeSystem.can_unlock_node("tier2_crit", unlocked) is True
    assert TalentTreeSystem.can_unlock_node("tier2_cd_reduct", unlocked) is False
